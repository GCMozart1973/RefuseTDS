import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { RefuseCompany } from '../_models/refuseCompany';
import { environment } from '../../environments/environment';
import { map } from 'rxjs';
import { RefuseLocation } from '../_models/refuseLocation';
import { RefuseRegion } from '../_models/refuseRegion';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  private http = inject(HttpClient);
  private baseUrl = environment.baseUrl;
  
  refuseCompanies = signal<RefuseCompany | null>(null)
  refuseLocations = signal<RefuseLocation | null>(null)
  refuseRegions = signal<RefuseRegion | null>(null)

  getCompanies(){
    return this.http.get<RefuseCompany>(`${this.baseUrl}Location/getRefuseCompanies`) .pipe(map(companies => {
      if (companies) {
        console.warn(companies);
        this.refuseCompanies.set(companies);
        // console.warn(this.refuseCompanies());
      }
    }))
  }

  getRefuseLocations(refuseCompanyId){
    return this.http.get<RefuseLocation>(`${this.baseUrl}Location/getRefuseLocations?companyId=`+refuseCompanyId)
    .pipe(map(locations=>{
      this.refuseLocations.set(locations);
    }))
  }

  getRefuseRegions(refuseCompanyId){
    return this.http.get<RefuseRegion>(`${this.baseUrl}Location/getRefuseRegions?companyId=`+refuseCompanyId)
    .pipe(map(regions=>{
      this.refuseRegions.set(regions);
      console.log('regions ', this.refuseRegions())
    }))
  }
}
