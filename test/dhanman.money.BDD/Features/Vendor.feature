Feature: Vendor
Vendor features

Link to a feature: [Vendor](dhanman.money.BDD/Features/Vendor.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**
A short summary of the feature

Background: User generates token for Authorisation
Given I am an authorized User
@referentials
Scenario: Authorized user is able to Add and Remove Vendor
	Given A list of vendors are available
	When I add a 'Vendor' to my vendor list
	| Name   | ContactPerson | Email  | PhoneNumber | Address |
	| Amazon | ABCContact    | Online | 123456789   | Online  |
	Then vendor is added
	