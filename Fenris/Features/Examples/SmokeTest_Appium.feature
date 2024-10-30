Feature: SmokeTest_Appium

    @Smart3D
    @Android
    @iOS
    Scenario: Smoke test for Gandalf with hearing instruments connected verifying the sliders
        Given I am in 'Live Mode' with hearing instruments connected
    #Given I press 'Allow While Using App' button in Always Allow dialog
    #And I press 'Change to Always Allow' button in Always Allow dialog
    #When I press 'No thanks' on 'Welcome - Would you like a quick tour of the app' dialog
        And I press split surroundings volume on 'All-Around' program
        Then HI Program is in 'All-Around'
        Then validate Right HI volume is '9'
        And validate Left HI volume is '9'
        When I set surroundings volume to '3' on 'right' volume bar of 'All-Around' program
        And I set surroundings volume to '10' on 'left' volume bar of 'All-Around' program
        Then validate Right HI volume is '3'
    #And validate Left HI volume is '10'
    #And validate surroundings volume is '3' on 'right' volume bar of 'All-Around' program
    #And validate surroundings volume is '10' on 'left' volume bar of 'All-Around' program
    #When I press merge surroundings volume on 'All-Around' program
    #Then validate HI volume is '3'
    #And validate merged surroundings volume bar is '3' on 'All-Around' program
    #When I set surroundings volume to '13' on 'All-Around' program
    #Then validate HI volume is '13'
    #And validate merged surroundings volume bar is '13' on 'All-Around' program
        #When I press 'Speech clarity' quick button on 'All-Around' program
        Then validate 'Speech clarity' quick button is enabled on 'All-Around' program
        #When I press 'Noise filter' quick button on 'All-Around' program
        Then validate 'Noise filter' quick button is enabled on 'All-Around' program
    #And validate 'Speech clarity' quick button is disabled on 'All-Around' program
        #When I press 'Speech clarity' quick button on 'All-Around' program
    #Then validate 'Noise filter' quick button is disabled on 'All-Around' program
        Then validate 'Speech clarity' quick button is enabled on 'All-Around' program
        When I press Sound Enhancer button on 'All-Around' program
        And I set Bass gain to '4' on 'All-Around' Sound Enhancer
        And I set Middle gain to '-3' on 'All-Around' Sound Enhancer
        And I set Treble gain to '5' on 'All-Around' Sound Enhancer
    #Then validate Bass gain is '4' on 'All-Around' Sound Enhancer
    #And validate Middle gain is '-3' on 'All-Around' Sound Enhancer
    #And validate Treble gain is '5' on 'All-Around' Sound Enhancer
        When I press 'Tinnitus Manager' on 'All-Around' Sound Enhancer
    #And I press Nature sounds button 'Calming Waves' on 'All-Around' Tinnitus Manager
    #And I press Nature sounds button 'Breaking Waves' on 'All-Around' Tinnitus Manager
        When I press the exit button on 'All-Around' Sound Enhancer
        And I swipe 'left' to 'Hear in Noise' program from current program
        Then HI Program is in 'Hear in Noise'
    #And validate program card is 'Hear in Noise'
        When I press Sound Enhancer button on 'Hear in Noise' program
        And I press 'Tinnitus Manager' on 'Hear in Noise' Sound Enhancer
    #And I press white noise button 'Slight variation' on 'Hear in Noise' Tinnitus Manager
    #When I press 'Reset' button on Hear in Noise Tinnitus Manager
        When I press the exit button on 'Hear in Noise' Sound Enhancer

    @Smart3D
    @Android
    @iOS
    Scenario: Smoke test for Gandalf with hearing instruments connected checking the program cards
        Given I am in 'Live Mode' with hearing instruments connected
        And I swipe 'left' to 'Hear in Noise' program from current program
        Then HI Program is in 'Hear in Noise'
    #And validate program card is 'Hear in Noise'
        When I press Sound Enhancer button on 'Hear in Noise' program
        And I press 'Tinnitus Manager' on 'Hear in Noise' Sound Enhancer
    #And I press white noise button 'Slight variation' on 'Hear in Noise' Tinnitus Manager
    #When I press 'Reset' button on Hear in Noise Tinnitus Manager
        When I press the exit button on 'Hear in Noise' Sound Enhancer
        When I swipe 'left' to 'Outdoor' program from current program
        Then HI Program is in 'Outdoor'
    #And validate program card is 'Outdoor'
        When I press Sound Enhancer button on 'Outdoor' program
        #And I drag Wind Noise Reduction to 'Strong' on 'Outdoor' Sound Enhancer
    #Then validate HI PNR value is 'Strong'
        When I press the exit button on 'Outdoor' Sound Enhancer
        And I swipe 'left' to 'Music' program from current program
        Then HI Program is in 'Music'
    #And validate program card is 'Music'
        When I press 'Music' program on the top ribbon bar
        Then HI Program is in 'Music'
    #And validate program card is 'Music'
        When I press 'Outdoor' program on the top ribbon bar
        Then HI Program is in 'Outdoor'
    #And validate program card is 'Outdoor'
        When I press 'Hear in Noise' program on the top ribbon bar
        Then HI Program is in 'Hear in Noise'
    #And validate program card is 'Hear in noise'
        When I press 'All-Around' program on the top ribbon bar
        Then HI Program is in 'All-Around'
    #And validate program card is 'All-Around'
        When I press Program overview button on topribbonbar
        And I press 'Hear in Noise' program on Program overview
        Then HI Program is in 'Hear in Noise'
        When I press 'Outdoor' program on Program overview
        Then HI Program is in 'Outdoor'
        When I press 'Music' program on Program overview
        Then HI Program is in 'Music'
        When I press 'All-Around' program on Program overview
        Then HI Program is in 'All-Around'
        When I press the 'Close' button on Program overview

    @Smart3D
    @Android
    @iOS
    Scenario: Smoke test for Gandalf with hearing instruments connected verifying the botton ribbon bar icons
        Given I am in 'Live Mode' with hearing instruments connected
        When I press menu item 'My ReSound' on bottom ribbon bar
        And I press 'Learn about the app' on My ReSound
        And I press 'Volume control' on Learn about the app
        And I swipe 'left' to '2 / 3' page on Learn about the app
    #Then validate 'Left and right volume' animation is shown on Volume control
        When I swipe 'left' to '3 / 3' page on Learn about the app
    #Then validate 'Mute' animation is shown on Volume control
        When I close on Learn about the app and back to My Resound page
        And I press 'Guiding tips' on My ReSound
        And I press 'OK' on 'Please notice' dialog
        Then validate title is 'Guiding tips' on Guiding tips page
        When I press 'Noise filter' on Guiding tips
        And I press Got it on 'Noise filter' nudging dialog
        And I press 'My Resound' on bottom ribbon bar and back to 'Guiding tips' on My Resound
        And I press 'Music program' on Guiding tips
        Then validate 'Got it' button enabled on 'Music program' nudging dialog
        Then validate 'Back to tips' button enabled on 'Music program' nudging dialog
        When I press Got it on 'Music program' nudging dialog
        And I press menu item 'More' on bottom ribbon bar
        Then validate 'Auto-activate favorite locations' switch is on
        When I press 'Auto-activate favorite locations' switch on More menu
    #Then validate 'Auto-activate favorite locations' switch is off
    #When I press 'Auto-activate favorite locations' switch on More menu
    #Then validate 'Auto-activate favorite locations' switch is on
        When I press 'Guiding tips' switch on More menu
        When I complete the Guiding Tips flow by pressing 'Start from the beginning' till 'Go' on the Guiding tips page
        Then validate 'Guiding tips' switch is on
        When I press 'Guiding tips' switch on More menu
        Then validate 'Guiding tips' switch is off
        When I press more menu item 'About'
        Then validate page title is displayed on About page
    #And validate html view is displayed on About page
        When I press back from 'About' page
        And I press more menu item 'Legal information'
        And I press Legal information item 'MANUFACTURER'
        Then validate page title is displayed on Manufacturer page
        When I press back from 'Manufacturer' page
        And I press Legal information item 'TERMS AND CONDITIONS'
        Then validate page title is displayed on Terms and Conditions page
        When I press back from 'Terms and Conditions' page
        And I press Legal information item 'PRIVACY POLICY'
    #Then validate html view is displayed on PRIVACY POLICY page
        And validate page title is displayed on PRIVACY POLICY page
        When I press back from 'PRIVACY POLICY' page
        And I press back from 'Legal information' page
        And I press more menu item 'Support'
    #Then validate html view is displayed on Support page
        And validate page title is displayed on Support page
        When I press back from 'Support' page
        And I press menu item 'Home' on bottom ribbon bar