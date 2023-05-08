import { forEach } from 'lodash';
import { ContractServiceProxy, InBillServiceProxy, OutBillServiceProxy, InvoiceServiceProxy } from './../../../shared/service-proxies/service-proxies';
import { Component, Injector, OnInit, ViewChild, ViewEncapsulation, Pipe } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { finalize } from 'rxjs/operators';
import * as moment from 'moment';



@Component({
    templateUrl: './host-dashboard.component.html',
    styleUrls: ['./host-dashboard.component.less'],
    encapsulation: ViewEncapsulation.None
})
export class HostDashboardComponent extends AppComponentBase implements OnInit {
    contractData: { name: string, value: number }[]= [];
    contractMoney: { name: string, value: number }[]= [];
    yearFilter  = moment().add(-1, 'year');
    outBillData=[0,0,0,0,0,0,0,0,0,0,0,0];
    inBillData=[0,0,0,0,0,0,0,0,0,0,0,0];
    invoiceData=[0,0,0,0,0,0,0,0,0,0,0,0];
    showXAxis: boolean = true;
    showYAxis: boolean = true;
    gradient: boolean = true;
    showLegend: boolean = true;
    showXAxisLabel: boolean = true;
    xAxisLabel: string = 'Tháng';
    showYAxisLabel: boolean = true;
    yAxisLabel: string = 'Tổng tiền';
    legendTitle: string = 'Loại ';
    name:any[]=["Tổng thu phí phát sinh", "Tổng chi", "Tổng thu phí điện nước"];
    multi: any[];
    colorScheme = {
      domain: ['#a7e082', '#be3030', '#1aa4f3']
    };

    view: any[] = [1200, 600];

    constructor(
        injector: Injector,
        private _contract :ContractServiceProxy,
        private _inBill :InBillServiceProxy,
        private _outBill :OutBillServiceProxy,
        private _invoice :InvoiceServiceProxy,

        ) {
        super(injector);
    }
    ngOnInit(): void {
        this.onGridReady();
        setTimeout(() => {
            this.setDashboardData();
          }, 1000);


    }
    onGridReady()
    {
        this.getContract(this.yearFilter);
        this.getInBill(this.yearFilter);
        this.getOutBill(this.yearFilter);
        this.getInvoice(this.yearFilter);
        this.getContractMoney(this.yearFilter);
    };
    getContract(year)
    {
        this._contract.getTotalContractForDashboard(year).subscribe(res=>{
            this.contractData = [];
                forEach(res, (item) => {
                    switch (item.month) {
                        case "1":
                            this.contractData.push({ name:"Tháng 1", value: item.total });
                            break;
                        case "2":
                            this.contractData.push({ name:"Tháng 2", value: item.total });
                            break;
                        case "3":
                            this.contractData.push({ name:"Tháng 3", value: item.total });
                            break;
                        case "4":
                            this.contractData.push({ name:"Tháng 4", value: item.total });
                            break;
                        case "5":
                            this.contractData.push({ name:"Tháng 5", value: item.total });
                            break;
                        case "6":
                            this.contractData.push({ name:"Tháng 6", value: item.total });
                            break;
                        case "7":
                            this.contractData.push({ name:"Tháng 7", value: item.total });
                            break;
                        case "8":
                            this.contractData.push({ name:"Tháng 8", value: item.total });
                            break;
                        case "9":
                            this.contractData.push({ name:"Tháng 9", value: item.total });
                            break;
                        case "10":
                            this.contractData.push({ name:"Tháng 10", value: item.total });
                            break;
                        case "11":
                            this.contractData.push({ name:"Tháng 11", value: item.total });
                            break;
                        case "12":
                            this.contractData.push({ name:"Tháng 12", value: item.total });
                            break;
                        }
                    });
                });
            }

            getContractMoney(year)
            {
                this._contract.getTotalContractMoneyForDashboard(year).subscribe(res=>{
                    this.contractMoney = [];
                        forEach(res, (item) => {
                            switch (item.month) {
                                case "1":
                                    this.contractMoney.push({ name:"Tháng 1", value: item.total });
                                    break;
                                case "2":
                                    this.contractMoney.push({ name:"Tháng 2", value: item.total });
                                    break;
                                case "3":
                                    this.contractMoney.push({ name:"Tháng 3", value: item.total });
                                    break;
                                case "4":
                                    this.contractMoney.push({ name:"Tháng 4", value: item.total });
                                    break;
                                case "5":
                                    this.contractMoney.push({ name:"Tháng 5", value: item.total });
                                    break;
                                case "6":
                                    this.contractMoney.push({ name:"Tháng 6", value: item.total });
                                    break;
                                case "7":
                                    this.contractMoney.push({ name:"Tháng 7", value: item.total });
                                    break;
                                case "8":
                                    this.contractMoney.push({ name:"Tháng 8", value: item.total });
                                    break;
                                case "9":
                                    this.contractMoney.push({ name:"Tháng 9", value: item.total });
                                    break;
                                case "10":
                                    this.contractMoney.push({ name:"Tháng 10", value: item.total });
                                    break;
                                case "11":
                                    this.contractMoney.push({ name:"Tháng 11", value: item.total });
                                    break;
                                case "12":
                                    this.contractMoney.push({ name:"Tháng 12", value: item.total });
                                    break;
                                }
                            });
                        });
                    }
    getInvoice(year)
        {
            this._invoice.getInvoiceForDashboard(year)
                .subscribe(res=>{
                forEach(res, (item) => {
                    switch (item.month) {
                        case 1:
                            this.invoiceData[0]=item.total;
                            break;
                        case 2:
                            this.invoiceData[1]=item.total;
                            break;
                        case 3:
                            this.invoiceData[2]=item.total;
                            break;
                        case 4:
                            this.invoiceData[3]=item.total;
                            break;
                        case 5:
                            this.invoiceData[4]=item.total;
                            break;
                        case 6:
                            this.invoiceData[5]=item.total;
                            break;
                        case 7:
                            this.invoiceData[6]=item.total;
                            break;
                        case 8:
                            this.invoiceData[7]=item.total;
                            break;
                        case 9:
                            this.invoiceData[8]=item.total;
                            break;
                        case 10:
                            this.invoiceData[9]=item.total;
                            break;
                        case 11:
                            this.invoiceData[10]=item.total;
                            break;
                        case 12:
                            this.invoiceData[11]=item.total;
                            break;
                    }
                });
                });
            }
    getOutBill(year)
        {
            this._outBill.getOutBillForDashboard(year)
                .subscribe(res=>{
                forEach(res, (item) => {
                    switch (item.month) {
                        case 1:
                            this.outBillData[0]=item.total;
                            break;
                        case 2:
                            this.outBillData[1]=item.total;
                            break;
                        case 3:
                            this.outBillData[2]=item.total;
                            break;
                        case 4:
                            this.outBillData[3]=item.total;
                            break;
                        case 5:
                            this.outBillData[4]=item.total;
                            break;
                        case 6:
                            this.outBillData[5]=item.total;
                            break;
                        case 7:
                            this.outBillData[6]=item.total;
                            break;
                        case 8:
                            this.outBillData[7]=item.total;
                            break;
                        case 9:
                            this.outBillData[8]=item.total;
                            break;
                        case 10:
                            this.outBillData[9]=item.total;
                            break;
                        case 11:
                            this.outBillData[10]=item.total;
                            break;
                        case 12:
                            this.outBillData[11]=item.total;
                            break;
                    }
                });
            });
        }
    getInBill(year)
        {
            this._inBill.getInBillForDashboard(year)
            .subscribe(res=>{
                forEach(res, (item) => {
                    switch (item.month) {
                        case 1:
                            this.inBillData[0]=item.total;
                            break;
                        case 2:
                            this.inBillData[1]=item.total;
                            break;
                        case 3:
                            this.inBillData[2]=item.total;
                            break;
                        case 4:
                            this.inBillData[3]=item.total;
                            break;
                        case 5:
                            this.inBillData[4]=item.total;
                            break;
                        case 6:
                            this.inBillData[5]=item.total;
                            break;
                        case 7:
                            this.inBillData[6]=item.total;
                            break;
                        case 8:
                            this.inBillData[7]=item.total;
                            break;
                        case 9:
                            this.inBillData[8]=item.total;
                            break;
                        case 10:
                            this.inBillData[9]=item.total;
                            break;
                        case 11:
                            this.inBillData[10]=item.total;
                            break;
                        case 12:
                            this.inBillData[11]=item.total;
                            break;
                    }
                });
            });
        }
    setDashboardData()
        {
            this.multi=[
                {
                    "name": "Tháng 1",
                    "series": [
                    {
                    "name": this.name[0],
                    "value": this.inBillData[0]
                    },
                    {
                    "name": this.name[1],
                    "value": this.outBillData[0]
                    },
                    {
                    "name": this.name[2],
                    "value": this.invoiceData[0]
                    }
                    ]
                },
                {
                    "name": "Tháng 2",
                    "series": [
                    {
                        "name": this.name[0],
                        "value": this.inBillData[1]
                    },
                    {
                        "name": this.name[1],
                        "value": this.outBillData[1]
                    },
                    {
                        "name": this.name[2],
                        "value": this.invoiceData[1]
                    }
                    ]
                    },
                    {
                      "name": "Tháng 3",
                      "series": [
                        {
                          "name": this.name[0],
                          "value": this.inBillData[2]
                        },
                        {
                          "name": this.name[1],
                          "value": this.outBillData[2]
                        },
                        {
                            "name": this.name[2],
                            "value": this.invoiceData[2]
                        }
                      ]
                    },
                    {
                      "name": "Tháng 4",
                      "series": [
                        {
                          "name": this.name[0],
                          "value": this.inBillData[3]
                        },
                        {
                          "name": this.name[1],
                          "value": this.outBillData[3]
                        },
                        {
                            "name": this.name[2],
                            "value": this.invoiceData[3]
                        }
                      ]
                    },
                    {
                      "name": "Tháng 5",
                      "series": [
                        {
                          "name": this.name[0],
                          "value": this.inBillData[4]
                        },
                        {
                          "name": this.name[1],
                          "value": this.outBillData[4]
                        },
                        {
                            "name": this.name[2],
                            "value": this.invoiceData[4]
                        }
                      ]
                    },
                    {
                      "name": "Tháng 6",
                      "series": [
                        {
                          "name": this.name[0],
                          "value": this.inBillData[5]
                        },
                        {
                          "name": this.name[1],
                          "value": this.outBillData[5]
                        },
                        {
                            "name": this.name[2],
                            "value": this.invoiceData[5]
                        }
                      ]
                    },
                    {
                      "name": "Tháng 7",
                      "series": [
                        {
                          "name": this.name[0],
                          "value": this.inBillData[6]
                        },
                        {
                          "name": this.name[1],
                          "value": this.outBillData[6]
                        },
                        {
                            "name": this.name[2],
                            "value": this.invoiceData[6]
                        }
                      ]
                    },
                    {
                      "name": "Tháng 8",
                      "series": [
                        {
                          "name": this.name[0],
                          "value": this.inBillData[7]
                        },
                        {
                          "name": this.name[1],
                          "value": this.outBillData[7]
                        },
                        {
                            "name": this.name[2],
                            "value": this.invoiceData[7]
                        }
                      ]
                    },
                    {
                      "name": "Tháng 9",
                      "series": [
                        {
                          "name": this.name[0],
                          "value": this.inBillData[8]
                        },
                        {
                          "name": this.name[1],
                          "value": this.outBillData[8]
                        },
                        {
                            "name": this.name[2],
                            "value": this.invoiceData[8]
                        }
                      ]
                    },
                    {
                      "name": "Tháng 10",
                      "series": [
                        {
                          "name": this.name[0],
                          "value": this.inBillData[9]
                        },
                        {
                          "name": this.name[1],
                          "value": this.outBillData[9]
                        },
                        {
                            "name": this.name[2],
                            "value": this.invoiceData[9]
                        }
                      ]
                    },
                    {
                      "name": "Tháng 11",
                      "series": [
                        {
                          "name": this.name[0],
                          "value": this.inBillData[10]
                        },
                        {
                          "name": this.name[1],
                          "value": this.outBillData[10]
                        },
                        {
                            "name": this.name[2],
                            "value": this.invoiceData[10]
                        }
                      ]
                    },
                    {
                      "name": "Tháng 12",
                      "series": [
                        {
                          "name": this.name[0],
                          "value": this.inBillData[11]
                        },
                        {
                          "name": this.name[1],
                          "value": this.outBillData[11]
                        },
                        {
                            "name": this.name[2],
                            "value": this.invoiceData[11]
                        }
                      ]
                    }
                  ];
            }
    search()
        {
            this.outBillData=[0,0,0,0,0,0,0,0,0,0,0,0];
            this.inBillData=[0,0,0,0,0,0,0,0,0,0,0,0];
            this.invoiceData=[0,0,0,0,0,0,0,0,0,0,0,0];
            this.getContract(this.yearFilter);
            this.getInvoice(this.yearFilter);
            this.getOutBill(this.yearFilter);
            this.getInBill(this.yearFilter);
            this.getContractMoney(this.yearFilter);
            setTimeout(() => {
                this.setDashboardData();
              }, 1000);
        }

    }
