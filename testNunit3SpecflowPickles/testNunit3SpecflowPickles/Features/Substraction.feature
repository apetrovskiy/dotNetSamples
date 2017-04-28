Feature: Substraction
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the difference between two numbers

@mytag
Scenario: Substraction of two numbers
	Given I have entered 50 as a first operand
	When I have substracted 70 from the first operand
	Then the long result should be -20 on the screen
