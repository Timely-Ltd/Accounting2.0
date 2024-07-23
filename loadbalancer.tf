# Load Balancer Rule config terraform
resource "azurerm_lb_rule" "accountingweb" {
  name                  = "accountingweb-lb-rule"
  resource_group_name   = azurerm_resource_group.accountingweb.name
  loadbalancer_id       = azurerm_lb.accountingweb.id
  frontend_ip_configuration_name = azurerm_lb.accountingweb.frontend_ip_configuration[0].name
  backend_address_pool_id = azurerm_lb_backend_address_pool.accountingweb.id
  probe_id               = azurerm_lb_probe.accountingweb.id
  protocol               = "Tcp"
  frontend_port          = 80
  backend_port           = 80
  enable_tcp_reset       = false
  # changed 10/6 to least connections for better load balancing
  load_distribution      = "LeastConnections"  
  #load_distribution      = "SourceIP"  # Sticky sessions based on client IP

  # Optional: Idle timeout in minutes (default is 4 minutes)
   load_balancing_rule {
     idle_timeout_in_minutes = 20
   }
}

# Output the Public IP address
output "public_ip_address" {
  value = azurerm_public_ip.accountingweb.ip_address
}