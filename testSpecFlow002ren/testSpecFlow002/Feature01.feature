﻿#@BeforeTestRun @BeforeFeature @AfterFeature @AfterTestRun @tag01 @Before @After @BeforeScenario @AfterScenario @BeforeScenarioBlock @AfterScenarioBlock @BeforeStep @AfterStep
Feature: Feature01
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

# @tag01 @Before @After @BeforeScenario @AfterScenario @BeforeScenarioBlock @AfterScenarioBlock @BeforeStep @AfterStep
@ScenarioName
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	And I have entered 80 into the calculator
	And I set flag=TRUE
	When I press add
	And I press add
	# Then the result should be 120 on the screen
	Then the result should be 200 on the screen
	When I press add
	Then the result should be 200 on the screen
	And I set flag=FALSE

# @tag01 @Before @After @BeforeScenario @AfterScenario @BeforeScenarioBlock @AfterScenarioBlock @BeforeStep @AfterStep
@ScenarioName
Scenario: Add two numbers with error
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	And I have entered 80 into the calculator
	And I set flag=TRUE
	When I press add
	And I press add
	# Then the result should be 120 on the screen
	Then the result should be 205 on the screen
	When I press add
	Then the result should be 205 on the screen
	And I set flag=FALSE