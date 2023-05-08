export const SalesVehicleKey = {
    // SalesVehicle
    remark: "remark",
    externalColorId: "externalColorId",
    cbulineOfMonthDate: "cbulineOfMonthDate",

    // Group Production
    audioId :"audioId",
    paintInTime:"paintInTime",
    paintInDate:"paintInDate",
    sequenceNo: "sequenceNo",
    lotInNo: "lotInNo",
    noInLot: "noInLot",
    tmssNo: "tmssNo",
    bodyNo: "bodyNo",
    ain: "ain",
    aout: "aout",
    keyCode: "keyCode",
    driverNo: "driverNo",
    passengerNo: "passengerNo",
    engineCode: "engineCode",
    transmissionNo: "transmissionNo", // Thay bằng TransmissionNo
    sideAirbagLh: "sideAirbagLh",
    sideAirbagRh: "sideAirbagRh",
    kneeAirbag: "kneeAirbag",
    axleNo: "axleNo",
    lineOffShift: "lineOffShift",
    lineOffDate: "lineOffDate",
    originalLineOffPlanDate: "originalLineOffPlanDate",
    originalLineOffPlanTime: "originalLineOffPlanTime",// Thay bằng OriginalLineOffPlanTime
    latestLineOffPlanDate: "latestLineOffPlanDate",
    // Group PIO
    pdiDate:  "pdiDate",
    pdiTime: "pdiTime",
    installPlanDate: "installPlanDate",
    installBeginPlanTime: "installBeginPlanTime",
    installPlanTime: "installPlanTime",
    installFinishPlanTime : "installFinishPlanTime",//Thêm trường InstallFinishPlanTime
    pioMember: "pioMember",
    installActualDate: "installActualDate",
    pioPay:  "pioPay",
    pioFloormat:  "pioFloormat",
    pioOwnerManual:  "pioOwnerManual",
    // Group Assigment
    tenantId:  "tenantId", //Thay bằng DealerId
    documentSendingRequestDate : "documentSendingRequestDate",
    colorRequestId:  "colorRequestId",
    colorDeadlineTime: "colorDeadlineTime",
    assignChangeFromDealerId: "assignChangeFromDealerId",
    assignChangeReason: "assignChangeReason",
    assignAllocationMonthDate: "assignAllocationMonthDate",
    assignChangeDate:  "assignChangeDate",// Thay bằng AssignChangeDate
    paymentDeadlinePlanDate: "paymentDeadlinePlanDate",
    invoiceRequestDate: "invoiceRequestDate",
    tmvInvoiceNo: "tmvInvoiceNo",
    tmvInvoiceDate: "tmvInvoiceDate",
    paymentDelay: "paymentDelay",
    tmvInvoiceVNAmount:  "tmvInvoiceVNAmount",
    tmvInvoiceUSDAmount:  "tmvInvoiceUSDAmount",
    paymentDeferDate:"paymentDeferDate",
    tmvFleetAmount: "tmvFleetAmount",
    fleetCustomer: "fleetCustomer", // Thay bằng FleetCustomer
    documentSendingDate: "documentSendingDate",
    // Group Document
    documentArrivalDate:  "documentArrivalDate",
    documentArrivalTime: "documentArrivalTime",
    documentVendorArrivalRemark: "documentVendorArrivalRemark",
    // Goup Remark
    dealerRemark:  "dealerRemark",
    // salesVehicleDamage
    damageStatusId: "damageStatusId",
    damageInsuranceCompanyId: "damageInsuranceCompanyId",
    damageRepaireCost: "damageRepaireCost",
    damageClaimDate: "damageClaimDate",
    damageFoundDate: "damageFoundDate",
    damageRepaireDate: "damageRepaireDate",
    damageFinishingDate: "damageFinishingDate",

    // salesVehicleTransportation
    cost: "cost",
    delayReason: "delayReason",
    gasoline: "gasoline",
    originalArrivalPlanDate: "originalArrivalPlanDate",
    temporaryLicenseDate: "temporaryLicenseDate",
    dispatchPlanDate: "dispatchPlanDate",
    dispatchPlanTime: "dispatchPlanTime",
    dispatchActualDate: "dispatchActualDate",
    dispatchActualTime: "dispatchActualTime",
    arrivalActualDate: "arrivalActualDate",
    arrivalActualTime: "arrivalActualTime",
    selfDivingTripRequestId : "selfDivingTripRequestId",
    routeID: "routeID",
    truckTypeId: "truckTypeId",
    arrivalToId: "arrivalToId",

    // salesVehicleMaintenance
    actualMaintenanceDate: "actualMaintenanceDate",
    planMaintenanceDate: "planMaintenanceDate",
    maintenanceStockDay: "maintenanceStockDay",
    noOfMaintenance: "noOfMaintenance",

    // salesVehicleCustom
    cbuInvoiceNo: "cbuInvoiceNo",
    cbuBillNo: "cbuBillNo",
    cbuCustomStartPlanDate: "cbuCustomStartPlanDate",
    cbuCustomStartActualDate: "cbuCustomStartActualDate",
    cbuCustomSheetNo: "cbuCustomSheetNo",
    cbuVrCheckActualDate: "cbuVrCheckActualDate",
    cbuVrCheckFinishDate: "cbuVrCheckFinishDate",
    cbuVRCertificateReceiveDate: "cbuVRCertificateReceiveDate",
    cbuPriceConsultDate: "cbuPriceConsultDate",
    cbuTmvOcSignDate: "cbuTmvOcSignDate",
    cbuCustomOcSignDate: "cbuCustomOcSignDate",
    cbuOriginDocumentPlanDate: "cbuOriginDocumentPlanDate",
    cbuLatestDocumentPlanDate: "cbuLatestDocumentPlanDate",
    cbuCustomCompleteActualDate: "cbuCustomCompleteActualDate",
    originDocumentPlanDate: "originDocumentPlanDate",
    customCompleteActualDate: "customCompleteActualDate",
    cbuDocumentDeliveryDate: "cbuDocumentDeliveryDate",
    cbuCustomActualLeadtime: "cbuCustomActualLeadtime",
    cbuVrCertificateLeadtime: "cbuVrCertificateLeadtime",
    cbuCustomRemark: "cbuCustomRemark",

    // salesVehicleLogisticSwap
    destinationId: "destinationId",
    routeId: "routeId",
    transportationCost: "transportationCost",
    reason: "reason",
    assignmentChangeDate: "assignmentChangeDate",

    //group delivery
    registerNo: 'registerNo',
    tripRequestId:'tripRequestId',
    saleAtDealerId:'saleAtDealerId',
    addressReceiveVehicleId:'addressReceiveVehicleId',
    truckLocationId:'truckLocationId',
    pdiLocationId:'pdiLocationId',
    tmvMovingYardDate:'tmvMovingYardDate',
    tmvMovingYardTime:'tmvMovingYardTime',

    //group document
    documentDeliveryDate : 'documentDeliveryDate',
    documentSendingVendorId : 'documentSendingVendorId'
};