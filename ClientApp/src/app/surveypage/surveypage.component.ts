import { Component } from '@angular/core';

@Component({
  selector: 'app-surveypage',
  templateUrl: './surveypage.component.html',
  styleUrls: ['./surveypage.component.css']
})
export class SurveypageComponent {

  surveyname = localStorage.getItem("SurveyName");
  creatorname = localStorage.getItem("CreatorName");
  CreationDay = parseInt(localStorage.getItem("CreationDay"));
  CreationMonth = parseInt(localStorage.getItem("CreationMonth"));
  CreationYear = parseInt(localStorage.getItem("CreationYear"));

  constructor( ) { }

}
