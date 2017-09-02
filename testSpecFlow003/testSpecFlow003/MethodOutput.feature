Feature: MethodOutput
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
#@secondTag @thirdTag
Scenario: Add two numbers
	Given I have added 50
	And I have added 70
	When I press calcs
	Then the result is 120
	#And the result is shown
	#But the result is shown
