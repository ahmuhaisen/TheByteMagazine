import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { catchError, map, throwError } from "rxjs";

import Swal from "sweetalert2";

import { Message } from "../models/message.model";
import { ApiResult } from "../models/api-response.model";
import { environment } from "../../../environments/environment";

@Injectable({ providedIn: 'root' })
export class ContactService {
    private httpClient = inject(HttpClient)


    sendMessage(message: Message) {
        return this.httpClient.post<{resData: ApiResult}>(`${environment.apiUrl}/contact`, message).pipe(
            catchError((error: HttpErrorResponse) => {
                this.showErrorMessage();
                return throwError(() => new Error(error.message));
            }),
            map((response) => response)
        )
        
    }

    showSuccessMessage(message?: string) {
        Swal.fire({
            icon: 'success',
            title: 'Message Sent',
            text: 'Thank you for your message. We will get back to you soon.',
          });
    }

    showErrorMessage() {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'An error occurred while sending the message. Please try again later.',
          });
    }
}