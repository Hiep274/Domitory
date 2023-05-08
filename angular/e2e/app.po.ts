import { browser, element, by, protractor, ExpectedConditions as EC } from 'protractor';

export class tmssPage {
    navigateTo() {
        return browser.get('/');
    }

    async getUsername() {
        return (await element(by.css('.kt-header__topbar-username')).getText()).replace('\n', '');
    }

    async waitForItemToBeVisible(element) {
        await browser.wait(EC.visibilityOf(element));
    }

    async loginAsHostAdmin() {
        let username = element(by.name('userNameOrEmailAddress'));
        let password = element(by.name('password'));

        await browser.get('/account/login');
        await this.waitForItemToBeVisible(username);

        await username.sendKeys('admin');
        await password.sendKeys('123qwe');
        await element(by.className('kt-form')).submit();
    }
}
