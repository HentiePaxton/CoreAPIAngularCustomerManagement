import { Component, Inject, ViewChildren, QueryList, AfterViewInit, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../models/customer';
import { ActivatedRoute } from '@angular/router';
import { Note } from '../models/note';
import { CustomerApiService } from '../customer-api.service';
import { Status } from '../models/status';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html'
})
export class CustomerDetailsComponent implements OnInit {

  newCustomer: boolean = true;
  customer: Customer = new Customer();
  statusList: Array<Status>
  moreDetails: boolean = false;

  constructor(
    public http: HttpClient,
    private route: ActivatedRoute,
    private apiservice: CustomerApiService,
    @Inject('BASE_URL') public baseUrl: string) {
  }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      let customerid = params.id;

      this.loadStatusList();

      if (customerid) {
        this.newCustomer = false;
        this.loadUser(customerid);
      } else {

        this.customer = <Customer>{ note: []};
        this.customer.note.push(new Note());
      }
    });
  }

  loadStatusList() {
    this.apiservice.getStatusList().subscribe(results => {
      this.statusList = results;
    });
  }

  AddNote() {
    this.customer.note.push(new Note());
  }


  RemoteNote(note) {
    var index = this.customer.note.indexOf(note);
    

    this.customer.note.splice(index, 1);
  }


  loadUser(customerId: string) {

    this.apiservice.getCustomerById(customerId).subscribe(result => {
      this.customer = <Customer>result;
      debugger;
      if (!this.customer.note || this.customer.note.length == 0) {
        this.customer.note.push(new Note());
      }
    }, error => console.error(error));

  }

  SaveCustomer() {
    debugger;
    if (this.newCustomer) {

      this.apiservice.createCustomer(this.customer).subscribe(result => {
        //this.customer = <Customer>result;
        alert("Customer Saved");

      }, error => console.error(error));
    } else {

      this.apiservice.updateCustomer(this.customer).subscribe(result => {
        //this.customer = <Customer>result;
        alert("Customer Saved");

      }, error => console.error(error));
    }
  }
}
