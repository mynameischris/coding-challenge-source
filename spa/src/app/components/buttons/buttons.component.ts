import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Activity } from '../../models/activity';
import { ActivityService } from '../../services/activity.service';

@Component({
    selector: 'app-buttons',
    templateUrl: './buttons.component.html',
    styleUrls: ['./buttons.component.css']
})
export class ButtonsComponent implements OnInit {
    @Output() addActivity: EventEmitter<Activity> = new EventEmitter();
    @Output() deleteActivities: EventEmitter<any> = new EventEmitter();

    constructor(private activityService: ActivityService) { }

    ngOnInit(): void {
    }

    onAdd() {
        this.activityService.getActivity()
            .subscribe(activity => this.addActivity.emit(activity), error => console.log(error));
    }

    onDeleteAll() {
        this.deleteActivities.emit();
    }
}