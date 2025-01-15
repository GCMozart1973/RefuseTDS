import { Component, inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LocationService } from '../../service/location.service';
import { UserService } from '../../service/user.service';
import { RefuseLocation } from '../../_models/refuseLocation';

@Component({
  selector: 'app-register',
  standalone : false,
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent implements OnInit{

  private userService = inject(UserService);
  private locationService = inject(LocationService);

  registerErrorMessage: string | null = null;
  registrationSuccessful: boolean = false;
  companyId: number | null = null;
  locationId : number | null  = null;
  regionId : number | null = null;

  ngOnInit(): void {
    this.locationService.getCompanies().subscribe();    
    
  }

  refuseCompanyChange(){
    console.error(this.companyId);
    this.locationService.getRefuseLocations(this.companyId).subscribe();
    this.locationId = 0;

    this.locationService.getRefuseRegions(this.companyId).subscribe();
  }

  refuseLocationChange(): void {
    var locations : any;
    locations = this.locationService.refuseLocations();
    const index = locations.findIndex((x) => x.locationID === this.locationId);
  
    if (index !== -1) {
      this.regionId = locations[index].regionID;
    } else {
      console.error(`Location with ID ${this.locationId} not found`);
    }
  }

  passwordsMatch(form: NgForm): boolean {
    const password = form.controls.password?.value;
    const reenterPassword = form.controls.reenterPassword?.value;
    return password === reenterPassword;
  }

  formSubmit(form: NgForm): void {
    if (form.valid) {
      console.log(this.companyId)
      console.log(this.locationId);
      this.userService.register(form.value).subscribe({
        next:(user)=>{
          this.registrationSuccessful = true;
          form.reset();
        },
        error:(e)=>{
          this.registerErrorMessage = e.error;
        }
      });
    }
  }
}
