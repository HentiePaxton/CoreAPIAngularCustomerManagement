import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from './models/customer';

@Injectable()
export class CustomerApiService {
  apiURL: string = 'http://www.server.com/api/';

  constructor(private httpClient: HttpClient,
  @Inject('BASE_URL') public baseUrl: string) { }



  public createCustomer(customer: Customer) {
    let filterQuery = this.baseUrl + 'api/Customers/';
    let body = customer;

    return this.httpClient.post<any>(filterQuery, body)
  }
    
  public updateCustomer(customer: Customer) {
    let filterQuery = this.baseUrl + 'api/Customers/' + customer.pkCustomerId;
    let body = customer;

    return this.httpClient.put<any>(filterQuery, body);
  }


  public getCustomerById(id: string) {

    let filterQuery = this.baseUrl + 'api/Customers/' + id;

    return this.httpClient.get<any>(filterQuery);
  }

  public getFilteredCustomers(searchTerm: string, sortColumn: string, page: number, pageSize: number ) {
    let filterQuery = this.baseUrl + 'api/Customers/FilterAndPage?IncludeCount=true';
    if (searchTerm) {
      filterQuery += '&Search=' + searchTerm;
    }
    if (sortColumn) {
      filterQuery += '&SortField=' + sortColumn;

    }
    filterQuery += '&PageNumber=' + page;
    filterQuery += '&PageSize=' + pageSize;

    return this.httpClient.get<any>(filterQuery);
  }

  public getStatusList() {

    let filterQuery = this.baseUrl + 'api/Status';

    return this.httpClient.get<any>(filterQuery);

  }

}
