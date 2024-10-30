Feature: NAP_ButtonTest

@Example @UIGallery
Scenario: Verify UIGallery Primary Button Pressed
    Given I launch the plugin app
    When I press 'Button Page' on UIGallery Menu Page
    And I press 'Primary Button' on UIGallery Button Page
    Then Validate that all buttons are disabled on the UIGallery Button Page

                                                                                                                         