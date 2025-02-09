from playwright.sync_api import Page, expect # type: ignore


def test_example(page: Page) -> None:
    page.goto("https://heroku-dotnet-razor-pages-742922653e59.herokuapp.com/Customers")
    page.screenshot(path="playwright/screenshots/Customers/Index.png")
    page.get_by_role("link", name="Create New").click()
    page.locator("#Customer_Name").click()
    page.locator("#Customer_Name").fill("Create by Playwright")
    page.screenshot(path="playwright/screenshots/Customers/Create/Create.png")
    page.get_by_role("button", name="Submit").click()
    page.screenshot(path="playwright/screenshots/Customers/Create/Customers.png")
    page.close()


