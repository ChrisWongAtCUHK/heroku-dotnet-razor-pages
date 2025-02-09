from playwright.sync_api import Page, expect # type: ignore


def test_example(page: Page) -> None:
    page.goto("https://heroku-dotnet-razor-pages-742922653e59.herokuapp.com/")
    page.get_by_role("link", name="Create").click()
    page.screenshot(path="playwright/screenshots/Create.png")
    page.close()


