import { Note } from "./note";
import { Status } from "./status";

export class Customer {
  pkCustomerId: number;
  firstname: string;
  lastname: string;
  email: string;
  cellNo: string;
  address: string;
  city: string;
  region: string;
  country: string;
  postalCode: string;
  customerId: string;
  status: string;
  createDate: string;
  passportNo: string;
  fkStatusId: number;
  fkStatus: Status;
  note: Note[];
}
