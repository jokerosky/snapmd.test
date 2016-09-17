import { NgModule }      from '@angular/core';
import { BrowserModule, DomSanitizer } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { HttpModule }    from '@angular/http';

import { AppComponent }   from './app.component';
import { SolverService }  from './services/solver.service';

@NgModule({
    imports: [  BrowserModule,
                FormsModule,
                HttpModule
    ],

    declarations: [AppComponent],
    providers: [
        SolverService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }