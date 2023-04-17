import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { User } from '../_models/user';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../_models/employee';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  constructor(
    private http: HttpClient,
    private accountService: AccountService
  ) {}

  url = 'https://localhost:7095/api/';

  userId: number | undefined;

  getAllEmployee() {
    return this.http.get<any>(`${this.url}User`).pipe(
      map((response) => {
        return response.data;
      })
    );
  }
  getEmpById(id: string) {
    return this.http.get<any>(`${this.url}User/${id}`).pipe(
      map((response) => {
        return response.data;
      })
    );
  }

  getUserById(id: string) {
    return this.http.get<any>(`${this.url}Account/${id}`);
  }

  updateEmployee(data: any) {
    return this.http.put<any>(`${this.url}User`, data);
  }
  updateUserProfile(data: any) {
    return this.http.get<any>(`${this.url}Account/${data.id}`);
  }
  addEmployee(data: Employee) {
    this.accountService.currentUser$.subscribe((val) => {
      console.log(val);
      data.userId = val?.id;
    });
    return this.http.post<any>(`${this.url}Employee`, data);
  }
  deleteEmployee(employeeId: number) {
    return this.http.delete(`${this.url}Employee?employeeId=${employeeId}`);
  }
}
