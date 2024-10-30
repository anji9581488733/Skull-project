Feature: Accessibility Test
    Modify the text size in Accessibility in native settings
    
    @Example
    Scenario Outline: Modify the text size in Accessibility in native settings
        Given I launch the plugin app
        And I get the initial text size of 'Font List Plugin'
        Given Go to native settings
        When I scroll 'Down' and press 'Accessibility' on 'NativeSettingsPage'
        When I press 'Display & Text Size' on 'NativeAccessibilityPage'
        And I press 'Larger Text' on 'NativeAccessibilityPage'
        And I press 'Larger Accessibility Sizes' toggle on 'NativeAccessibilityPage'
        When I move the slider to '<slider_percent>' percent   
        Given I terminate the plugin app
        Given I launch the plugin app
        Then The text size of 'Font List Plugin' should be modified
        Given Go to native settings
        When I scroll 'Down' and press 'Accessibility' on 'NativeSettingsPage'
        When I press 'Display & Text Size' on 'NativeAccessibilityPage'
        And I press 'Larger Text' on 'NativeAccessibilityPage'
        When I press 'Larger Accessibility Sizes' toggle on 'NativeAccessibilityPage'
        And I reset the slider to '0' percent
        And I close the settings
        
        Examples:
          | slider_percent |
          | 45             |
          | 70             |
    
    
        