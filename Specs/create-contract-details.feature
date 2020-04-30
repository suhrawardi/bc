Feature: list klanten on the SOAP endpoint


  @browser @wip
  Scenario: list klanten on the SOAP endpoint
    Given a klanten SOAP endpoint
    When I fetch the first 3 records from the SOAP endpoint
    Then I received 3 records