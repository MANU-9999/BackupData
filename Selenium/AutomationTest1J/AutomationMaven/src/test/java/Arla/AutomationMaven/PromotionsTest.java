package Arla.AutomationMaven;

import PageObjects.PromotionsPage;
import TestData.PromotionsData;
import TestSetUp.Base;
import org.testng.annotations.Test;

import java.util.Arrays;
import java.util.List;

public class PromotionsTest extends Base {

    @Test(dataProvider = "InstantPromotionFOC", dataProviderClass = PromotionsData.class)
    public void InstantPromotionFOC(String promotionCode, String startDate,
                                    String endDate, String salesOrgdName, String routeType, String factsheet, String PromotionTypes, String desctription, String uom,
                                    String offerType, String orderQTY, String offerUOM, String offerOrderQTY) {

        PromotionsPage promotionsPage = new PromotionsPage();
        promotionsPage.NavigateToPromotionsPage();
        promotionsPage.SelectPromotionDetailsAndType(promotionCode, startDate, endDate, salesOrgdName, routeType, factsheet, PromotionTypes, desctription);

        List<String> routes = Arrays.asList("10115399", "10119708");
        promotionsPage.RouteWiseMapping(routes);
        promotionsPage.SaveMapping();

        List<String> items = Arrays.asList("990139", "991450");
        promotionsPage.AddingItemsWithPromotion(items, uom, offerType, orderQTY, offerUOM, offerOrderQTY);

    }

    @Test(dataProvider = "InstantPromotionDiscountPer", dataProviderClass = PromotionsData.class)
    public void InstantPromotionDiscountPer(String promotionCode, String startDate,
                                            String endDate, String salesOrgdName, String routeType, String factsheet, String PromotionTypes, String desctription, String uom,
                                            String offerType, String orderQTY, String offerUOM, String offerOrderQTY) {

        PromotionsPage promotionsPage = new PromotionsPage();
        promotionsPage.NavigateToPromotionsPage();
        promotionsPage.SelectPromotionDetailsAndType(promotionCode, startDate, endDate, salesOrgdName, routeType, factsheet, PromotionTypes, desctription);

        List<String> routes = Arrays.asList("10115399", "10119708");
        promotionsPage.RouteWiseMapping(routes);
        promotionsPage.SaveMapping();

        List<String> items = Arrays.asList("603372", "607114");
        promotionsPage.AddingItemsWithPromotion(items, uom, offerType, orderQTY, offerUOM, offerOrderQTY);

    }

    @Test(dataProvider = "InstantPromotionDiscountAmount", dataProviderClass = PromotionsData.class)
    public void InstantPromotionDiscountAmount(String promotionCode, String startDate,
                                               String endDate, String salesOrgdName, String routeType, String factsheet, String PromotionTypes, String desctription, String uom,
                                               String offerType, String orderQTY, String offerUOM, String offerOrderQTY) {

        PromotionsPage promotionsPage = new PromotionsPage();
        promotionsPage.NavigateToPromotionsPage();
        promotionsPage.SelectPromotionDetailsAndType(promotionCode, startDate, endDate, salesOrgdName, routeType, factsheet, PromotionTypes, desctription);

        List<String> routes = Arrays.asList("10115399", "10119708");
        promotionsPage.RouteWiseMapping(routes);
        promotionsPage.SaveMapping();

        List<String> items = Arrays.asList("66899", "87057");
        promotionsPage.AddingItemsWithPromotion(items, uom, offerType, orderQTY, offerUOM, offerOrderQTY);

    }

//Bundle Promotions--------------------	

    @Test(dataProvider = "BundlePromotionFOC", dataProviderClass = PromotionsData.class)
    public void BundlePromotionFOC(String promotionCode, String startDate,
                                   String endDate, String salesOrgdName, String routeType, String factsheet, String PromotionTypes, String desctription,
                                   String uOM, String totalQty, String minInvoiceAmount, String maxDeals, String discountTypeBundle, String discount, String uom, String orderQTY, String QTY) {

        PromotionsPage promotionsPage = new PromotionsPage();
        promotionsPage.NavigateToPromotionsPage();
        promotionsPage.SelectPromotionDetailsAndType(promotionCode, startDate, endDate, salesOrgdName, routeType, factsheet, PromotionTypes, desctription);


        List<String> routes = Arrays.asList("10115399", "10119708");
        promotionsPage.RouteWiseMapping(routes);
        promotionsPage.SaveMapping();

        promotionsPage.AddBundlePromotionDetails(uOM, totalQty, minInvoiceAmount, maxDeals, discountTypeBundle, discount);

        List<String> ActualItems = Arrays.asList("603372", "607114");
        promotionsPage.AddOrderItems(ActualItems, uom, orderQTY);

        List<String> OfferItems = Arrays.asList("990139", "991450");
        promotionsPage.AddOfferItems(OfferItems);

        promotionsPage.AddOfferedItemsQTY(OfferItems, QTY);

    }

    @Test(dataProvider = "BundlePromotionDiscountPer", dataProviderClass = PromotionsData.class)
    public void BundlePromotionDiscountPer(String promotionCode, String startDate,
                                           String endDate, String salesOrgdName, String routeType, String factsheet, String PromotionTypes, String desctription,
                                           String uOM, String totalQty, String minInvoiceAmount, String maxDeals, String discountTypeBundle, String discount, String uom, String orderQTY, String QTY) {

        PromotionsPage promotionsPage = new PromotionsPage();
        promotionsPage.NavigateToPromotionsPage();
        promotionsPage.SelectPromotionDetailsAndType(promotionCode, startDate, endDate, salesOrgdName, routeType, factsheet, PromotionTypes, desctription);


        List<String> routes = Arrays.asList("10115399", "10119708");
        promotionsPage.RouteWiseMapping(routes);
        promotionsPage.SaveMapping();

        promotionsPage.AddBundlePromotionDetails(uOM, totalQty, minInvoiceAmount, maxDeals, discountTypeBundle, discount);

        List<String> ActualItems = Arrays.asList("603372", "607114");
        promotionsPage.AddOrderItems(ActualItems, uom, orderQTY);

        List<String> OfferItems = Arrays.asList("990139", "991450");
        promotionsPage.AddOfferItems(OfferItems);

        promotionsPage.AddOfferedItemsQTY(OfferItems, QTY);
    }

    @Test(dataProvider = "BundlePromotionDiscountAmount", dataProviderClass = PromotionsData.class)
    public void BundlePromotionDiscountAmount(String promotionCode, String startDate,
                                              String endDate, String salesOrgdName, String routeType, String factsheet, String PromotionTypes, String desctription,
                                              String uOM, String totalQty, String minInvoiceAmount, String maxDeals, String discountTypeBundle, String discount, String uom, String orderQTY, String QTY) {

        PromotionsPage promotionsPage = new PromotionsPage();
        promotionsPage.NavigateToPromotionsPage();
        promotionsPage.SelectPromotionDetailsAndType(promotionCode, startDate, endDate, salesOrgdName, routeType, factsheet, PromotionTypes, desctription);


        List<String> routes = Arrays.asList("10115399", "10119708");
        promotionsPage.RouteWiseMapping(routes);
        promotionsPage.SaveMapping();

        promotionsPage.AddBundlePromotionDetails(uOM, totalQty, minInvoiceAmount, maxDeals, discountTypeBundle, discount);

        List<String> ActualItems = Arrays.asList("603372", "607114");
        promotionsPage.AddOrderItems(ActualItems, uom, orderQTY);

        List<String> OfferItems = Arrays.asList("990139", "991450");
        promotionsPage.AddOfferItems(OfferItems);


        promotionsPage.AddOfferedItemsQTY(OfferItems, QTY);


    }


    //Invoice level Promotions--------------------

    @Test(dataProvider = "InvoicePromotionDiscountPer", dataProviderClass = PromotionsData.class)
    public void InvoicePromotionDiscountPer(String promotionCode, String startDate,
                                            String endDate, String salesOrgdName, String routeType, String factsheet, String PromotionTypes,
                                            String desctription, String discountPerc, String minInvoice, String discountType) {

        PromotionsPage promotionsPage = new PromotionsPage();
        promotionsPage.NavigateToPromotionsPage();
        promotionsPage.SelectPromotionDetailsAndType(promotionCode, startDate, endDate, salesOrgdName, routeType, factsheet, PromotionTypes, desctription);


        List<String> routes = Arrays.asList("10115399", "10119708");
        promotionsPage.RouteWiseMapping(routes);
        promotionsPage.SaveMapping();

        promotionsPage.AddInvoicePromotionDetails(discountPerc, minInvoice, discountType);

    }
}
