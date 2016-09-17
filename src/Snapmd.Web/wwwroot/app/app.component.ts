import { Component } from '@angular/core';
import { SolverService } from './services/solver.service';
import {TransfusionsResult} from './models/transfusions-result';
import {TaskInput} from './models/task-input';
import './rxjs-operators';


@Component({
  selector: 'snapmd-app',
  templateUrl: '\\templates\\mainApp.html'
})


export class AppComponent {
    constructor(private solverService: SolverService) { }

    changed: boolean = false;
    noDecision: boolean;

    input: TaskInput = {
        jar1Capacity: 3,
        jar2Capacity: 5,
        targetAmount: 4
    }

    decision: TransfusionsResult = null;

    getDecision() {
        console.log('form submitted');
        this.noDecision = false;

        this.solverService.getDecision(this.input)
            .then(decision => {
                if (!decision.isPossible) {
                    this.noDecision = true;
                    this.decision = null;
                    return;
                }

                this.changed = false;
                this.decision = decision;
            });
    }

    onChange() {
        this.changed = true;
    }
}