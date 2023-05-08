import {
  Component, Input, OnInit, ViewChild,
  ViewContainerRef, Injector, ComponentRef, Output,
  EventEmitter, SimpleChanges, ChangeDetectorRef, SimpleChange,
  OnChanges, OnDestroy, NgModuleFactory,
  NgModuleRef, Compiler,
} from '@angular/core';
import { MODULE_COMPONENT_MAP } from '../../constants/module-component-map';

@Component({
  selector: 'dynamic-tab',
  templateUrl: './dynamic-tab.component.html',
  styleUrls: ['./dynamic-tab.component.less'],
})
export class DynamicTabComponent implements OnInit, OnChanges, OnDestroy {
  // @ViewChild(TemplateRef, { read: ViewContainerRef, static: false })
  // private compViewContainerRef: ViewContainerRef;
  @ViewChild('componentPlaceholder', { read: ViewContainerRef, static: false })
  componentPlaceholder: ViewContainerRef;
  @Input() tabCode;
  @Input() params;
  @Input() currentTabCode;
  @Output() event$ = new EventEmitter();
  @Output() setShortcuts = new EventEmitter();

  private moduleRef: NgModuleRef<any>;
  private componentRef: ComponentRef<any>;

  /**
   * Run when new an instance.
   *
   * @param cdr
   * @param injector
   * @param compiler
   */
  constructor(
    private cdr: ChangeDetectorRef,
    private injector: Injector,
    private compiler: Compiler
  ) { }
  ngOnInit() {

  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes.params && this.moduleRef && this.componentRef) {
      // if (changes.params && this.componentRef) {
      if (this.params) {
        // Why 'this'.params but not changes.params
        const _changes = {};
        // tslint:disable-next-line: forin
        for (const prop in this.params) {
          const oldValue = this.componentRef.instance[prop];
          if (this.params.hasOwnProperty(prop)) {
            // not inherited properties
            this.componentRef.instance[prop] = this.params[prop];
          }
          if (oldValue !== this.params[prop]) {
            _changes[prop] = new SimpleChange(
              oldValue,
              this.params[prop],
              false
            );
          }
        }
        if (
          Object.keys(_changes).length &&
          this.componentRef.instance.ngOnChanges
        ) {
          this.componentRef.instance.ngOnChanges(_changes);
        }
      }
    }
  }

  ngOnDestroy() {
    this.moduleRef?.destroy();
    this.componentRef?.destroy();
  }

  /**
   * Run specific requirements (eg. reload, ngOnInit, remove) for the needed Tabs
   */
  runCustomFunction() {
    if (this.componentRef) {
      // Code: Fill code for Proposal Tab here
      // if (this.tab.startsWith(`${TMSSTabs.proposal}-`)) {
      //     this.componentRef.instance.reloadQuotation();
      //     return;
      // }
      // Code: Fill code for Other Tabs here
      // switch (this.tabCode) {
      //     case TMSSTabs.carWash:
      //         this.componentPlaceholder.remove();
      //         this.ngOnInit();
      //         break;
      //     default:
      //         break;
      // }
    }

    else {
        const module = this.getModulePath(this.currentTabCode);
        this.importModule(module);
    }
  }

  /**
   * Get the Module's path by tabCode. Use this path for dynamic create Module and Component instance
   *
   * @param tabCode
   */
  private getModulePath(tabCode) {
    for (const modulePath in MODULE_COMPONENT_MAP) {
      if (MODULE_COMPONENT_MAP[modulePath].includes(tabCode)) {
        return modulePath;
      }
    }

    return '';
  }

  /**
   *
   * @param t
   */
  private loadModuleFactorySync(t: any) {
    if (t instanceof NgModuleFactory) {
      return t;
    } else {
      return this.compiler.compileModuleSync(t);
    }
  }
  // Async Version
  // private async loadModuleFactory(t: any) {
  //   if (t instanceof NgModuleFactory) {
  //     return t;
  //   } else {
  //     return await this.compiler.compileModuleAsync(t);
  //   }
  // }

  /**
   * You have to set the Module Name and Module File Name as this convention:
   * + File name: lower-and-hyphen-separtor-name.module.ts
   * + Module name: LowerAndHyphenSeparatorNameModule (Remove hyphen and Upper first letter of each word)
   */
  private importModule(path: string) {
    let transformed = this.getMiddlePathAndModuleName(path);
    import(`app/${transformed.MiddlePath}/${transformed.RawModuleName.toLowerCase()}.module`)
      .then(
        m => {
          this.renderComponent(m[`${transformed.ModuleName}Module`]);
        }
      )
      .catch(err => {
        console.log(`error: Can not dynamically load ${path} module.`);
        console.log(err);
      });
  }
  /**
   *
   * @param module
   */
  private renderComponent(module: any) {
    const _modFac = this.loadModuleFactorySync(module);
    this.moduleRef = _modFac.create(this.injector);
    const _comp = (_modFac.moduleType as any).getComponent(this.normalizeTabCode(this.tabCode));
    const _compFactory = this.moduleRef.componentFactoryResolver.resolveComponentFactory(
      _comp
    );
    // this.compViewContainerRef.clear();
    // this.componentRef = this.compViewContainerRef.createComponent(
    //   _compFactory
    // );
    this.componentRef = this.componentPlaceholder.createComponent(
      _compFactory
    );
    this.setShortcuts.emit(this.componentRef);
    this.componentRef.instance.params = this.params;
    this.cdr.detectChanges();

  }

  private normalizeTabCode(rawCode: string) {
    if (rawCode.indexOf('---') >= 0) {
      return rawCode.substr(0, rawCode.indexOf('---'));
    } else {
      return rawCode;
    }
  }

  private getMiddlePathAndModuleName(path: string) {
    const separator = '/';
    const period = '.';
    const idxFirstSep = path.indexOf(separator);
    const idxLastSep = path.lastIndexOf(separator);
    const idxLastPeriod = path.lastIndexOf(period);

    // remove 'app/' and '/module-name.module'
    const middlePath = path.substr(idxFirstSep + 1, idxLastSep - idxFirstSep - 1);
    const rawModuleName = path.substr(idxLastSep + 1, idxLastPeriod - idxLastSep - 1);

    // Transform module name to Pascal Case
    let p = rawModuleName;
    p = p[0].toUpperCase() + p.substr(1, p.length - 1);

    const regex = /(-\w){1}/gi;

    return {
      MiddlePath: middlePath,
      ModuleName: p.replace(regex, (match) => match[1].toUpperCase()),
      RawModuleName: rawModuleName
    };
  }
}
