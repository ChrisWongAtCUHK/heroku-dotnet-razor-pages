from playwright.sync_api import Page, expect # type: ignore


def test_example(page: Page) -> None:
    page.goto("https://heroku-dotnet-razor-pages-742922653e59.herokuapp.com/Customers/Edit/1")
    page.get_by_label("Name").click()
    page.get_by_label("Name").fill("Edit by Playwright 1")
    page.screenshot(path="playwright/screenshots/Customers/Update/Update.png")
    page.get_by_role("button", name="Save").click()
    page.screenshot(path="playwright/screenshots/Customers/Update/Customers.png")
    page.close()


