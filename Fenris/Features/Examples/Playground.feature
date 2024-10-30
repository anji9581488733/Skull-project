Feature: Playground

    Scenario: Verify Welcome page present
        Given I launch the app
        And   I am at the welcome screen
 
    Scenario: Pending step - Last step will become blue in the report.
        Given I am in Demo Mode after installing the app
        When  I am pending a step
        

    @Smart3D @Android @iOS
    Scenario: Getting connected (with hearing aids through HIC)
        Given I am in 'Live Mode' with hearing instruments connected 


    @Android
    Scenario Outline: Android language test emulator - Change language
        Given I start the Android emulator
        Given I change language on emulator to '<language>'
    #Given I launch the app

        Examples:
          | language | region |   
          | en_US    | en     |

    Scenario: Launch the app
        Given I launch the app