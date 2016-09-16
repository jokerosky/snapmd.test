import { Component } from '@angular/core';
import { SolverService } from './services/solver.service';
import {TransfusionsResult} from './models/transfusionsResult';

@Component({
  selector: 'snapmd-app',
  templateUrl: '\\templates\\mainApp.html'
})


export class AppComponent {
    constructor(private solverService: SolverService) { }

    jar1Capacity: number = 3;
    jar2Capacity: number = 5;
    targetAmount: number = 4;

    decision: TransfusionsResult = null;

    getDecision() {
        console.log('form submitted');
        this.solverService.getDecision(this.jar1Capacity, this.jar2Capacity, this.targetAmount)
            .then(decision => {
                if (!decision.IsPossible) {
                    //showAlert();
                }
                this.decision = decision;
            });
    } 
}