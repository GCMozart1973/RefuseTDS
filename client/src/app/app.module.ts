// Core Module
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { BrowserAnimationsModule }               from '@angular/platform-browser/animations';
import { BrowserModule, Title }                  from '@angular/platform-browser';
import { HttpClientModule }                      from '@angular/common/http';
import { AppRoutingModule }                      from './app-routing.module';
import { NgModule }                              from '@angular/core';
import { FormsModule, ReactiveFormsModule }      from '@angular/forms';
import { provideHttpClient } from '@angular/common/http';

// Main Component
import { AppComponent }                    from './app.component';
import { HeaderComponent }                 from './components/header/header.component';
import { SidebarComponent }                from './components/sidebar/sidebar.component';
import { SidebarRightComponent }           from './components/sidebar-right/sidebar-right.component';
import { TopMenuComponent }                from './components/top-menu/top-menu.component';
import { PanelComponent }                  from './components/panel/panel.component';
import { FloatSubMenuComponent }           from './components/float-sub-menu/float-sub-menu.component';
import { ThemePanelComponent }             from './components/theme-panel/theme-panel.component';

// Component Module
import { NgScrollbarModule, NG_SCROLLBAR_OPTIONS } from 'ngx-scrollbar';

// Pages
import { HomePage }          from './pages/home/home';

// Error
import { ErrorPage }          from './pages/error/error';
import { Login } from './pages/login/login';
import { RegisterComponent } from './pages/register/register.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SidebarComponent,
    SidebarRightComponent,
    TopMenuComponent,
    PanelComponent,
    FloatSubMenuComponent,
    ThemePanelComponent,
    
    HomePage,
    Login,
    RegisterComponent,

    
    ErrorPage
  ],
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgScrollbarModule,
    FormsModule
    
  ],
  providers: [ 
    provideHttpClient(),
    Title, {
		provide: NG_SCROLLBAR_OPTIONS,
		useValue: {
			visibility: 'hover'
		}
  }],
  bootstrap: [ AppComponent ]
})

export class AppModule {
  constructor(private router: Router, private titleService: Title, private route: ActivatedRoute) {
    router.events.subscribe((e) => {
      if (e instanceof NavigationEnd) {
        var title = 'Color Admin | ' + this.route.snapshot.firstChild.data['title'];
        this.titleService.setTitle(title);
      }
    });
  }
}
