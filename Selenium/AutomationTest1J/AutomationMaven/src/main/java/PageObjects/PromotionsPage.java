package PageObjects;

import TestSetUp.Base;
import TestUtils.BrowserActions;
import TestUtils.WaitUtil;
import org.openqa.selenium.By;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebElement;

import java.util.List;

public class PromotionsPage extends Base {
    By TransactionsMenu = By.id("ancSfaAdministration");
    By CreatePaymentLink = By.linkText("Promotions");
    //AddBundlePromotionDetails
    By AddNew = By.cssSelector("a#cphContent_lnkAddNew");
    By PromotionCode = By.cssSelector("input#cphContent_txtPromotionCode");
    By StartDate = By.cssSelector("input#cphContent_txtStartDate");
    By EndDate = By.cssSelector("input#cphContent_txtEndDate");

    By SalesOrg = By.cssSelector("select#cphContent_ddlSalesOrgCode");
    By RouteType = By.cssSelector("select#cphContent_ddlRouteType");
    By Factsheet = By.cssSelector("select#cphContent_ddlFactsheet");

    By PromotionTypeInstant = By.xpath("//*[contains(@id,'100')]");
    By PromotionTypeBundle = By.xpath("//*[contains(@id,'104')]");
    By PromotionTypeInvoice = By.xpath("//*[contains(@id,'105')]");
    By Desctription = By.cssSelector("textarea#cphContent_txtDesctription");
    By Proceed = By.id("btnContinue1");

    By SelectRoute = By.xpath("//span[contains(text(),'Select Route')]");
    By EnterRoute = By.xpath("(//input[@placeholder =\"Enter keywords\"])[7]");
    By UploadFile = By.cssSelector("input#cphContent_FileUpload1");
    By ProceedButtonMapping = By.id("btnContinue2");

    By AddNewItem = By.linkText("Add New Item");
    By ItemSearch = By.cssSelector("input#txtInstantOrderItemCode");
    By PopUpSearch = By.id("txtitemsearch");
    By Add = By.cssSelector("input#btnAddItemModel");
    By CancelIcon = By.id("img9");

    By OrderUOM = By.cssSelector("select#ddlOrderUOM");
    By OrderQTY = By.id("txtOrderQtyOrAmt");

    By OfferType = By.cssSelector("select#ddlInstantofferType");
    By OfferItemCodeSearch = By.cssSelector("input#txtInstantOfferItemCode");
    By OfferUOM = By.cssSelector("select#ddlOfferUOMNew");
    By OfferQTY = By.cssSelector("input#txtOfferQtyOrAmt");
    By SavePopUp = By.cssSelector("a#ancAdd");
    By OfferAmount = By.cssSelector("input#txtOfferQtyOrAmt");
    By OfferDiscount = By.cssSelector("input#txtOfferQtyOrAmt");
    //AddInvoicePromotionDetails
    By DiscountPerc = By.cssSelector("input#txtInvoiceDiscount");
    By MinInvoice = By.cssSelector("input#cphContent_txtMinInvoice");
    By DiscountType = By.id("cphContent_ddlInvoiceLevelDiscount");
    By SaveButton = By.cssSelector("a#save");
    //AddBundlePromotionDetails
    By UOM = By.cssSelector("select#cphContent_ddlMainTotalUOM");
    By TotalQty = By.id("cphContent_txtTotalQty");
    By MinInvoiceAmount = By.id("cphContent_txtMinInvoiceAmount");
    By MaxDeals = By.id("cphContent_txtMaxDeal");

    By OfferTypeDiscountBundle = By.cssSelector("input#cphContent_rbtdiscount");
    By OfferTypeFOCBundle = By.cssSelector("input#cphContent_rbtfoc");
    By DiscountBundleType = By.id("cphContent_ddlDiscountTypeQTY");
    By Discount = By.id("cphContent_TxtDiscount");

    By UpdateButton = By.cssSelector("a#a12");
    By AddNewOffer = By.linkText("Add New");
    By ItemCodeSearchPopUp = By.cssSelector("input#txtbundleOfferItemCode");
    By SaveBundleItem = By.cssSelector("a#ancAdd");
    By SaveOfferItem = By.xpath("(//div/a[contains(text(),'Save')])[5]");


    public void NavigateToPromotionsPage() {
        WaitUtil.WaitForLoaderToComplete();
        BrowserActions.Click(TransactionsMenu);
        BrowserActions.Click(CreatePaymentLink);
        WaitUtil.WaitForLoaderToComplete();
    }

    public void SelectPromotionDetailsAndType(String promotionCode, String startDate, String endDate, String salesOrg,
                                              String routeType, String factsheet, String PromotionTypes, String desctription) {

        BrowserActions.Click(AddNew);
        WaitUtil.WaitForLoaderToComplete();
        BrowserActions.Type(PromotionCode, promotionCode);
        BrowserActions.SelectDate(StartDate, startDate);
        BrowserActions.SelectDate(EndDate, endDate);
        BrowserActions.Select(SalesOrg, salesOrg);
        BrowserActions.Select(RouteType, routeType);
        BrowserActions.Select(Factsheet, factsheet);

        String PromotionType = PromotionTypes;
        switch (PromotionType) {
            case "Instant":
                BrowserActions.Click(PromotionTypeInstant);
                BrowserActions.Type(Desctription, desctription);
                BrowserActions.Click(PromotionTypeInstant);
                break;
            case "Bundle":
                BrowserActions.Click(PromotionTypeBundle);
                BrowserActions.Type(Desctription, desctription);
                BrowserActions.Click(PromotionTypeBundle);
                break;
            case "Invoice":
                BrowserActions.Click(PromotionTypeInvoice);
                BrowserActions.Type(Desctription, desctription);
                BrowserActions.Click(PromotionTypeInvoice);
                break;
        }
        BrowserActions.Click(Proceed);
        WaitUtil.Sleep10();
    }


    public void RouteWiseMapping(List<String> routes) {
        BrowserActions.Click(SelectRoute);
        for (String route : routes) {
            BrowserActions.Click(EnterRoute);
            BrowserActions.Clear(EnterRoute);
            BrowserActions.Type(EnterRoute, route);
            WebElement CheckBox = driver
                    .findElement(By.xpath("//div/ul/li/label/input[contains(@value,'" + route + "')]"));
            BrowserActions.WebElementJSFindAndClick(CheckBox);
            // BrowserActions.Type(UploadFile,
            // "C:\\Users\\winit\\Pictures\\Screenshots\\Screenshot (1).png");
        }
    }

    public void SaveMapping() {
        BrowserActions.Click(ProceedButtonMapping);
        WaitUtil.shortSleep();
    }

    public void AddingItemsWithPromotion(List<String> items, String uom, String offerType, String orderQTY,
                                         String offerUOM, String offerValue) {
        for (String item : items) {
            BrowserActions.Click(AddNewItem);
            BrowserActions.Click(ItemSearch);

            WaitUtil.shortSleep();
            BrowserActions.Type(PopUpSearch, item);
            WaitUtil.shortSleep();
            try {
                WebElement ActualItem = driver.findElement(By.xpath("//div[label[contains(text(),'" + item + "')]]"));
                WebElement radio = ActualItem.findElement(By.cssSelector("input[type='radio']"));
                radio.click();
                BrowserActions.Click(Add);
                WaitUtil.shortSleep();
                BrowserActions.Select(OrderUOM, uom); /// CASE .PCS
                BrowserActions.Type(OrderQTY, orderQTY);

                BrowserActions.Select(OfferType, offerType); // Discount Amount
                String OfferType = offerType;
                switch (OfferType) {
                    case "Qty":
                        FOC(item, offerUOM, offerValue);
                        break;
                    case "Discount %":
                        BrowserActions.Type(OfferAmount, offerValue);
                        BrowserActions.Click(SavePopUp);
                        WaitUtil.shortSleep();
                        break;
                    case "Discount Amount":
                        BrowserActions.Type(OfferDiscount, offerValue);
                        BrowserActions.Click(SavePopUp);
                        WaitUtil.shortSleep();
                        break;
                }

            } catch (NoSuchElementException e) {
                BrowserActions.Click(CancelIcon);
                System.out.println(item + " : Actual Item is not availble please check once");
            }

        }

    }

    public void OfferItem(String item) {
        BrowserActions.JSFindAndClick(OfferItemCodeSearch);
        BrowserActions.Type(PopUpSearch, item);
        WaitUtil.shortSleep();
        WebElement OfferItem = driver.findElement(By.xpath("//div[label[contains(text(),'" + item + "')]]"));
        WebElement radioo = OfferItem.findElement(By.cssSelector("input[type='radio']"));
        radioo.click();
        BrowserActions.Click(Add);
        WaitUtil.shortSleep();
    }

    public void FOC(String item, String offerUOM, String offerValue) {
        BrowserActions.Select(OfferUOM, offerUOM); // Discount Amount
        BrowserActions.Type(OfferQTY, offerValue); /// CASE .PCS
        try {
            OfferItem(item);
            BrowserActions.Click(SavePopUp); // Discount Amount
        } catch (NoSuchElementException e) {
            BrowserActions.Click(CancelIcon);
            System.out.println(item + " :Offer Item is not availble please check once");
        }
    }

    public void AddInvoicePromotionDetails(String discountPerc, String minInvoice, String discountType) {
        BrowserActions.Type(DiscountPerc, discountPerc);
        BrowserActions.Type(MinInvoice, minInvoice);
        BrowserActions.Select(DiscountType, discountType);
        BrowserActions.Click(SaveButton);
        WaitUtil.shortSleep();
    }

    public void AddBundlePromotionDetails(String uOM, String totalQty, String minInvoiceAmount, String maxDeals, String discountBundleType, String discount) {
        BrowserActions.Select(UOM, uOM);
        BrowserActions.Type(TotalQty, totalQty);
        BrowserActions.Type(MinInvoiceAmount, minInvoiceAmount);
        BrowserActions.Type(MaxDeals, maxDeals);

        BrowserActions.Click(OfferTypeDiscountBundle);
        BrowserActions.Select(DiscountBundleType, discountBundleType);
        BrowserActions.Type(Discount, discount);

        BrowserActions.Click(Add);

    }


    //Order Items
    public void AddOrderItems(List<String> ActualItems, String uom, String orderQTY) {
        for (String item : ActualItems) {

            try {
                WebElement ItemChecking = driver
                        .findElement(By.xpath("(//table/tbody/tr[@itemcode='" + item + "'])[1]"));
                if (ItemChecking != null) {
                    System.out.println(item + " : Is already in the item ORDER items list");
                } else {
                    System.out.println(item + " :is adding");
                }

            } catch (NoSuchElementException e) {
                AddOrderItemsFLOW(item, uom, orderQTY);
            } catch (Exception e) {
                System.out.println(e);
            }

        }
    }

    public void AddOrderItemsFLOW(String item, String uom, String orderQTY) {
        BrowserActions.ScrollToElement(AddNewItem);
        WaitUtil.shortSleep();
        BrowserActions.Click(AddNewItem);
        BrowserActions.Click(ItemSearch);
        WaitUtil.WaitForLoaderToComplete();
        BrowserActions.Type(PopUpSearch, item);
        WaitUtil.shortSleep();
        try {
            WebElement ActualItem = driver.findElement(By.xpath("//div[label[contains(text(),'" + item + "')]]"));
            WebElement radio = ActualItem.findElement(By.cssSelector("input[type='radio']"));
            radio.click();
            BrowserActions.Click(Add);
            WaitUtil.shortSleep();

            BrowserActions.Select(UOM, uom);
            BrowserActions.Type(OrderQTY, orderQTY);
            BrowserActions.Click(SaveBundleItem);

        } catch (NoSuchElementException e) {
            BrowserActions.Click(CancelIcon);
            System.out.println(item + " : Actual Item is not availble please check once");
        } catch (Exception e) {
            BrowserActions.Click(CancelIcon);
            System.out.println(item + "  :" + e);
        }
    }

    //Offer Items
    public void AddOfferItems(List<String> OfferItems) {

        for (String item : OfferItems) {

            try {
                WebElement ItemChecking = driver
                        .findElement(By.xpath("(//table/tbody/tr[@itemcode='" + item + "'])[1]"));
                if (ItemChecking != null) {
                    System.out.println(item + " : Is already in the item OFFERED items list");
                } else {
                    System.out.println(item + " :is adding");
                }

            } catch (NoSuchElementException e) {
                AddOfferItemsFLOW(item);
            } catch (Exception e) {
                System.out.println(e);
            }

        }

    }

    public void AddOfferItemsFLOW(String item) {

        BrowserActions.ScrollToElement(AddNewOffer);
        WaitUtil.shortSleep();
        BrowserActions.Click(AddNewOffer);
        BrowserActions.Click(ItemCodeSearchPopUp);
        WaitUtil.WaitForLoaderToComplete();
        WaitUtil.shortSleep();
        BrowserActions.Type(PopUpSearch, item);
        WaitUtil.shortSleep();
        try {
            WebElement ActualItem = driver.findElement(By.xpath("//div[label[contains(text(),'" + item + "')]]"));
            WebElement radio = ActualItem.findElement(By.cssSelector("input[type='radio']"));
            radio.click();
            BrowserActions.JSFindAndClick(Add);
            WaitUtil.shortSleep();
            BrowserActions.Click(SaveOfferItem);
            WaitUtil.WaitForLoaderToComplete();
        } catch (NoSuchElementException e1) {
            BrowserActions.Click(CancelIcon);
            System.out.println(item + " : Actual Item is not availble please check once");
        }

    }


    public void AddOfferedItemsQTY(List<String> items, String QTY) {
        WaitUtil.shortSleep();
        for (String item : items) {
            WebElement ItemChecking = driver.findElement(By.xpath("(//table/tbody/tr[@itemcode='" + item + "'])[1]"));
            WebElement Text = ItemChecking.findElement(By.cssSelector("input.ordered"));
            Text.click();
            Text.sendKeys(QTY);
        }
    }

}
