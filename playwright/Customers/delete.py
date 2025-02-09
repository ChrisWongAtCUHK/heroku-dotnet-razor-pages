from playwright.sync_api import Page, expect # type: ignore


def test_example(page: Page) -> None:
    page.goto("https://heroku-dotnet-razor-pages-742922653e59.herokuapp.com/Customers")
    page.get_by_role("row", name="1 Customer 1 Edit | delete").get_by_role("button", name="delete").click()
    page.screenshot(path="playwright/Customers/screenshots/Delete/Customers.png")
    page.close()


