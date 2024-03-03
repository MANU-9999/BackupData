package TestUtils;

import TestSetUp.Base;
import org.openqa.selenium.*;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.ui.Select;

import java.awt.*;
import java.awt.datatransfer.StringSelection;
import java.awt.event.KeyEvent;
import java.io.File;
import java.security.SecureRandom;
import java.time.Month;
import java.time.format.TextStyle;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.List;
import java.util.Locale;

public class BrowserActions extends Base {

    public static void JSFindAndClick(By field) {
        WebElement element = driver.findElement(field);
        JavascriptExecutor js = (JavascriptExecutor) driver;
        js.executeScript("arguments[0].click();", element);
    }

    public static void WebElementJSFindAndClick(WebElement field) {
        WebElement element = (field);
        JavascriptExecutor js = (JavascriptExecutor) driver;
        js.executeScript("arguments[0].click();", element);
    }

    public static float GetTextByJavaScriptExecutor(By field) {
        WebElement ele = driver.findElement(field);
        JavascriptExecutor js = (JavascriptExecutor) driver;
        String textboxvalue1 = (String) js.executeScript("return arguments[0].value;", ele);

        float textboxvalue = Float.parseFloat(textboxvalue1);
        return textboxvalue;
    }
//---------------	

    public static void WaitAndclick(By element) {
        WaitUtil.waitForElementToBeClickable(element);
        driver.findElement(element).click();
    }

    public static void MHCLick(By element) {
        Actions a = new Actions(driver);
        WebElement ele = driver.findElement(element);
        a.moveToElement(ele).click();
    }

    public static void typeValue(By element, String value) {
//		WaitUtil.FluentWait(element);
        driver.findElement(element).sendKeys(value);

    }

    public static String GetText(By element) {
//		WaitUtil.visibilityOfElementLocated(element);
        String Text = driver.findElement(element).getText();
        return Text;
    }

    public static void ScrollToElement(By field) {
        Actions act = new Actions(driver);
        act.scrollToElement(driver.findElement(field)).build().perform();
    }

    public static void ScrollUp() {
        Actions act = new Actions(driver);
        act.sendKeys(Keys.HOME).build().perform();

    }

    public static void ScrollDown() {
        Actions act = new Actions(driver);
        act.sendKeys(Keys.END).build().perform();
    }

    public static void PageDown() {
        Actions act = new Actions(driver);
        act.sendKeys(Keys.PAGE_DOWN).build().perform();
    }

    public static void JSScrollToWebElement(WebElement ele) {
        JavascriptExecutor js = (JavascriptExecutor) driver;
        js.executeScript("arguments[0].scrollIntoView(true);", ele);

    }

    public static void Clear(By field) {
        WaitUtil.waitForElementToBeClickable(field);
        driver.findElement(field).clear();
    }

    public static void Select(By field, String value) {
        WaitUtil.waitForElementToBeClickable(field);
        WebElement element = driver.findElement(field);
        Select dropDown = new Select(element);
        dropDown.selectByVisibleText(value);
    }

    public static void Type(By field, String value) {
        WaitUtil.waitForElementToBeClickable(field);
        driver.findElement(field).sendKeys(value);
    }

    public static void Click(By field) {

        WaitUtil.waitForElementToBeClickable(field);
        driver.findElement(field).click();
    }

    public static void ClickP(By field) {

        WaitUtil.presenceOfElementLocated(field);
        driver.findElement(field).click();
    }

    public static void SelectDate(By field, String value) {
        JavascriptExecutor js = (JavascriptExecutor) driver;
        WebElement inputField = driver.findElement(field);
        js.executeScript("arguments[0].value = arguments[1]", inputField, value);
        js.executeScript("arguments[0].dispatchEvent(new KeyboardEvent('keydown', { 'key': 'Tab' }))", inputField);
    }

    public static void TypeFloatValue(By field, double value) {
        WaitUtil.waitForElementToBeClickable(field);
        String s = Double.toString(value);
        driver.findElement(field).sendKeys(s);
    }

    public static void ClickTab() {
        Actions act = new Actions(driver);
        act.sendKeys(Keys.TAB).build().perform();
    }

    public static void ClickEnter() {
        Actions act = new Actions(driver);
        act.sendKeys(Keys.ENTER).build().perform();
    }

    public static void ImportfileFormat(String filename) {

        String filePath = "C:" + File.separator + "Users" + File.separator + "winit" + File.separator + "Downloads" + File.separator + filename + ".xls";

        try {
            Robot robot = new Robot();
            StringSelection stringSelection = new StringSelection(filePath);
            Toolkit.getDefaultToolkit().getSystemClipboard().setContents(stringSelection, null);
            robot.keyPress(KeyEvent.VK_CONTROL);
            robot.keyPress(KeyEvent.VK_V);
            robot.keyRelease(KeyEvent.VK_V);
            robot.keyRelease(KeyEvent.VK_CONTROL);


            robot.keyPress(KeyEvent.VK_ENTER);
            robot.keyRelease(KeyEvent.VK_ENTER);
        } catch (AWTException e) {
            System.out.println(e);
        }

    }

    public static void AlertPopAccept() {
        Alert alert = driver.switchTo().alert();
        alert.accept();
    }

    public static double GetDoubleValue(By field) {
        WaitUtil.waitForElementToBeClickable(field);
        String Text = driver.findElement(field).getText();
        double Value = Double.parseDouble(Text);
        System.out.println(Value);
        return Value;
    }

    public static void Zoomout() {
        Actions act = new Actions(driver);

        act.keyDown(Keys.CONTROL);
        act.sendKeys(Keys.SUBTRACT);
        act.keyUp(Keys.CONTROL);
        act.build().perform();

    }

    //-------------------------------------------------------------------------------------
    public static Double ReceiptNumbertext;

    public static List<Object> AfterPaymentGetDetailsByRow(String number) {

        WebElement row = driver.findElement(By.xpath("//tbody/tr[td/span[@title='" + number + "' ]][1]"));
        String ReceiptNumberFinalValue = row.findElement(By.xpath("//tr/td[1]/span[@title]")).getAttribute("title");
        String PaymentModeFinalValue = row.findElement(By.xpath("//tr/td[7]/span[@title]")).getAttribute("title");
        String AmountFinalValue = row.findElement(By.xpath("//tr/td[9]/span[@title]")).getAttribute("title");
        Double ReceiptNumbertext = Double.parseDouble(ReceiptNumberFinalValue);

        return Arrays.asList(ReceiptNumberFinalValue, PaymentModeFinalValue, AmountFinalValue);
    }

    public static List<Double> OutStandingLinesGetText(String Invoicenumber) {
        WebElement row = driver.findElement(By.xpath("//tbody/tr[td/span[@title='" + Invoicenumber + "' ]]"));
        WaitUtil.shortSleep();

        double PendingCheque = Double.parseDouble(
                row.findElement(By.xpath(".//td[11]/span[contains(@id,'cphContent_gvLocation_lblAttribute1_')]"))
                        .getAttribute("title"));
        double OutStandingAmount = Double.parseDouble(
                row.findElement(By.xpath(".//td[12]/span[contains(@id,'cphContent_gvLocation_lblOutStandingAmount_')]"))
                        .getAttribute("title"));

        List<Double> resultList = new ArrayList<>();
        resultList.add(PendingCheque);
        resultList.add(OutStandingAmount);
        return resultList;
    }

    public static void SelectActionButton(String UserCode) {
        String xpathExpression = "//tbody/tr[td/span[contains(@title,'{UserCode}')]]/td/a[@id='cphContent_gvPayment_lnkView_0']";
        WebElement action = driver.findElement(By.xpath(xpathExpression));
        action.click();
    }

    public static WebElement FindingRowIWebElement(String number) {
        WebElement row = driver.findElement(By.xpath("//tbody/tr[td/span[@title='" + number + "' ]]"));
        // tbody/tr[td/span[@title='" + Invoicenumber + "' ]]
        // IWebElement ReceiptNumber = row.FindElement(By.XPath("(//tr/td/span[@title])[1]"));
        // string s = ReceiptNumber.GetAttribute("title");
        // Console.WriteLine(s);
        return row;
    }
    
    public static String GetSytemTime() {
//    	Date date = new Date();
//		String lastDate = (date.toString().trim());
//		System.out.println(lastDate);

		Month currentMonth = Month.from(java.time.LocalDate.now()); // DECEMBER
		String monthName = currentMonth.getDisplayName(TextStyle.FULL, Locale.getDefault()); // December
		System.out.println(monthName);
        return monthName;   
    }

	public static String RandomText(int length) {

		final String CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		StringBuilder randomString = new StringBuilder(length);
		SecureRandom random = new SecureRandom();

		for (int i = 0; i < length; i++) {
			int randomIndex = random.nextInt(CHARACTERS.length());
			char randomChar = CHARACTERS.charAt(randomIndex);
			randomString.append(randomChar);
		}
		return randomString.toString();
	}
    
    
    
}
