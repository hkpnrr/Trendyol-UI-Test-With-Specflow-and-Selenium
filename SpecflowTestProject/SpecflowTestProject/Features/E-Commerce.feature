Feature: E-Commerce
	Test that adds a product to basket then deletes it

@mytag
Scenario: Add product to basket then delete
	Given enter the website
	And close popup
	And type the sentence for search product
	When click first search result
	And if color options of product popup exists close popup
	And click first product
	And switch browser tab
	And click add to basket button
	Then save name of product
	When click account basket button
	And find added product and delete it
	Then close window
	