import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

import { Activity } from '../models/Activity';

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
}

@Injectable({
    providedIn: 'root'
})
export class ActivityService {
    activityUrl: string = 'http://www.boredapi.com/api/activity';
    activitiesUrl: string = 'http://localhost:5000/api/ActivityItems';

    constructor(private http:HttpClient) { }

    getActivities(): Observable<Activity[]> {
        return this.http
            .get<Activity[]>(this.activitiesUrl)
            .pipe(catchError(error => throwError(error.message)));
    }

    getActivity(): Observable<Activity> {
        return this.http
            .get<Activity>(this.activityUrl)
            .pipe(catchError(error => throwError(error.message)));
    }

    addActivity(activity: Activity): Observable<Activity> {
        return this.http
            .post<Activity>(this.activitiesUrl, activity, httpOptions)
            .pipe(catchError(error => throwError(error.message)));
    }

    deleteActivities() {
        return this.http
            .delete<any>(this.activitiesUrl)
            .pipe(catchError(error => throwError(error.message)));
    }
}