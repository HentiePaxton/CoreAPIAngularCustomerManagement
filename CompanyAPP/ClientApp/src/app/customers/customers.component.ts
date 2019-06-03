import { Component, Inject, ViewChildren, QueryList, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../models/customer';
import { NgbdSortableHeader, SortEvent, SortDirection } from '../directives/sortable.directive';
import { CustomerHeader } from '../models/customerHeader';
import { CustomerApiService } from '../customer-api.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html'
})
export class CustomersComponent implements AfterViewInit {
  public customers: Customer[];
  Arr = Array;
  page: number = 1;
  pageSize: number = 10;
  pageCount: number = 5;
  searchTerm: string = "";
  sortColumn: string = "";
  sortDirection: SortDirection;
  firstRowOnPage = false;
  lastRowOnPage = false;
  tableHeaders: Array<CustomerHeader> = [];

  @ViewChildren(NgbdSortableHeader) headers: QueryList<NgbdSortableHeader>;

  constructor(
    public http: HttpClient,
    private apiservice: CustomerApiService,
    @Inject('BASE_URL') public baseUrl: string) {
    this.fiterCustomers();
  }

  ngAfterViewInit() {
    //add table headers
    this.populateHeaders();
    this.sort(this.tableHeaders[0]);
  }

  sort(header: CustomerHeader) {

    if (header.sort == null || header.sort == false || header.direction == "desc") {
      header.sort = true;
      header.direction = "asc";
      this.sortColumn = header.name.trim();
    } else {
      header.sort = true;
      header.direction = "desc";
      this.sortColumn = header.name.trim() + "_desc";
    }

    this.tableHeaders.forEach(function (item) {
      if (header.name != item.name) {
        item.direction = null;
        item.sort = null;
      }
    });

    this.fiterCustomers();

  }

  populateHeaders() {

    this.tableHeaders.push(<CustomerHeader>{ name: "Firstname" });
    this.tableHeaders.push(<CustomerHeader>{ name: "Lastname" });
    this.tableHeaders.push(<CustomerHeader>{ name: "Email" });
    this.tableHeaders.push(<CustomerHeader>{ name: "Cell No" });
    this.tableHeaders.push(<CustomerHeader>{ name: "Status" });
    this.tableHeaders.push(<CustomerHeader>{ name: "Passport No" });
  }

  

  fiterCustomers(selectedPage: number = null) {

    if (selectedPage) {
      this.page = selectedPage;
    }

   
    this.apiservice.getFilteredCustomers(this.searchTerm, this.sortColumn, this.page, this.pageSize).subscribe(result => {
      this.customers = result.results;
      this.page = result.currentPage;
      this.pageCount = result.pageCount;
      this.pageSize = result.pageSize;
      this.firstRowOnPage = (result.firstRowOnPage == this.page);
      this.lastRowOnPage = ((result.rowCount / result.pageCount) == this.page);
    }, error => console.error(error));
  }
}
