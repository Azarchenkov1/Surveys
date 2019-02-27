import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SurveypageComponent } from './surveypage.component';

describe('SurveypageComponent', () => {
  let component: SurveypageComponent;
  let fixture: ComponentFixture<SurveypageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SurveypageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SurveypageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
