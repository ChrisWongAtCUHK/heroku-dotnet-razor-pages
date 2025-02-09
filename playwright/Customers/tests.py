from playwright.sync_api import Page, expect # type: ignore


def test_example(page: Page) -> None:
    baseUrl = "https://heroku-dotnet-razor-pages-742922653e59.herokuapp.com/"
    screenshotsPath = "playwright/Customers/screenshots/"
    page.goto(baseUrl + "Customers")

    # Customers/Index
    page.screenshot(path=screenshotsPath + "Index.png")
    page.get_by_role("link", name="Create New").click()
    page.locator("#Customer_Name").fill("Create by Playwright")
    page.screenshot(path=screenshotsPath + "Create/Create.png")
    page.get_by_role("button", name="Submit").click()
    page.screenshot(path=screenshotsPath + "Create/Customers.png")
    
    # Customers/Edit
    page.goto(baseUrl + "Customers/Edit/1")
    page.get_by_label("Name").click()
    page.get_by_label("Name").fill("Edit by Playwright 1")
    page.screenshot(path=screenshotsPath + "Update/Update.png")
    page.get_by_role("button", name="Save").click()
    page.screenshot(path=screenshotsPath + "Update/Customers.png")

    # Customers delete
    page.goto(baseUrl + "Customers")
    # TODO: insert or update SQL before test
    page.get_by_role("row", name="2 Customer 2 Edit | delete").get_by_role("button", name="delete").click()
    page.screenshot(path="playwright/Customers/screenshots/Delete/Customers.png")
    page.close()


