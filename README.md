# test-ui

## Overview

This repo contains a test automation framework built with c#,Specflow and Playwright.It is designed to test the login functionality of sample web app(found online to test dummy application) by verifying successful login and validating error messages for invalid login attempts.

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
- Config/: Contains configuration files (e.g., appsettings.json).
- Pages/: Page Object Models (POM) for interacting with web pages.
- Features/: Gherkin feature files for test scenarios.
- Steps/: Step definitions implementing test logic.
- Setup/: Playwright initialization, hooks, and configurations.
