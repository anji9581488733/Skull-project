Feature: NAP_CheckboxTest
    
@Example @UIGallery
Scenario: Verify UIGallery First Checkbox Is Changing Value Every 2 Seconds
    Given I launch the plugin app
    When I press 'Checkbox Page' on UIGallery Menu Page
    Then Validate that the checkbox 'Checkbox1' is enabled on the UIGallery Checkbox Page

#@Example @UIGallery
#Scenario: Verify Second Checkbox Is Disabled
#    Given I launch the plugin app
#    When I press 'Checkbox Page' on UIGallery Menu Page
#    Then Validate that the checkbox 'Checkbox2' is disabled on the UIGallery Checkbox Page

@Example @UIGallery
Scenario: Verify UIGallery Third Checkbox Is Checked By Default
    Given I launch the plugin app
    When I press 'Checkbox Page' on UIGallery Menu Page
    Then Validate that the checkbox 'Checkbox3' is enabled on the UIGallery Checkbox Page
    
    