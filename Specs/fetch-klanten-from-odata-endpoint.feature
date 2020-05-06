Feature: list klanten on the ODATA endpoint


  @browser @wip
  Scenario: list klanten on the ODATA endpoint
    Given a klanten ODATA endpoint
    When I fetch the first 3 records from the ODATA endpoint
    Then I should have 3 records