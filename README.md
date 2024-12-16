# test-ui

## Overview

This repo contains a test automation framework built with c#,Specflow and Playwright.It is designed to test the login functionality of sample web app(found online to test dummy application) by verifyinf successful login and validating error messages for invalid login attempts.

### Required software to run locally

- [.NET 7.0 SDK]
- Playwright CLI
- Visual Studio 

## Project setup
1.Clone the repo:
git clone https://github.com/sgolyala87/test-ui
2.Restore dependencies
dotnet restore
3.Install Playwright browsers
playwright install

## Project structure
- Config: Contains configuration files, including appsettings.json, which stores settings like the application URL and login credentials.
- Features: Includes Gherkin feature files describing the test cases.
- Steps: Contains step definitions that implement the logic for feature file steps.
- Setup: Framework setup files, such as Playwright initialization and configuration utilities.
