import { Component, OnInit } from '@angular/core';
import { Activity } from '../../models/activity';
import { ActivityService } from '../../services/activity.service';

@Component({
    selector: 'app-activities',
    templateUrl: './activities.component.html',
    styleUrls: ['./activities.component.css']
})
export class ActivitiesComponent implements OnInit {
    activities: Activity[];

    constructor(private activityService: ActivityService) { }

    ngOnInit(): void {
        this.getActivities();
        console.log(this.activities);
    }

    getActivities() {
        this.activityService.getActivities()
            .subscribe(activities => this.activities = activities.sort((a, b) => a.id - b.id), error => console.log(error));
    }

    addActivity(activity) {
        //add to array
        this.activities.push(activity);
        //add to database
        this.activityService.addActivity(activity)
            .subscribe(activity => console.log(activity), error => console.log(error));
    }

    deleteActivities() {
        //remove all activities from array
        this.activities = [];
        //remove all activities from database
        this.activityService.deleteActivities()
            .subscribe(response => console.log(response), error => console.log(error));
    }
}