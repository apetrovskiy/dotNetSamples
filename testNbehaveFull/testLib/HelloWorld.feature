Feature: HelloWorld
  A narrative is optional

Scenario: Login
  Given I am not logged in
  When I log in as Morgan with a password SecretPassw0rd
  Then I should see a message, "Welcome, Morgan!"