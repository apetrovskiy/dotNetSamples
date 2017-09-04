Feature: Feature02
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers 2
	Given I have entered 50 into the calculator
	Given the user orders the following items
		| Name                                                           | Price |
		| The Mythical Man-Month                                         | 29.09 |
		| The Phoenix Project                                            | 29.95 |
		| Design Patterns: Elements of Reusable Object-Oriented Software | 39.95 |
		| Lean In: Women, Work, and the Will to Lead                     | 11.22 |
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

@mytag
Scenario: Add two numbers 2a
	Given I have entered 50 into the calculator
	Given the user orders the following items 2nd way
		| Name                                                           | Price | Author |
		| The Mythical Man-Month                                         | 29.09 |        |
		| The Phoenix Project                                            | 29.95 |        |
		| Design Patterns: Elements of Reusable Object-Oriented Software | 39.95 |        |
		| Lean In: Women, Work, and the Will to Lead                     | 11.22 |        |
		#| The Mythical Man-Month                                         | 29 |
		#| The Phoenix Project                                            | 29 |
		#| Design Patterns: Elements of Reusable Object-Oriented Software | 39 |
		#| Lean In: Women, Work, and the Will to Lead                     | 11 |
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

@mytag
Scenario: Add two numbers 3
	Given I have entered 50 into the calculator
	Given the following customer
		| Name      | Value             |
		| FirstName | Lucy              |
		| LastName  | Buschmann         |
		| Email     | lucy.b@canine.com |
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

@mytag
Scenario: Add two numbers 3a
	Given I have entered 50 into the calculator
	Given the following customer 2nd way
		| Name      | Value             |
		| FirstName | Lucy              |
		| LastName  | Buschmann         |
		| Email     | lucy.b@canine.com |
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen