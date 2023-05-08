import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';

@Directive({
    selector: '[unless]'
})
export class UnlessDirective {
    @Input('component') component;
    scope;
    @Input() set unless(condition: Boolean) {
        if (condition) {
            this.vcRef.createEmbeddedView(this.templateRef);
            //   this.vcRef.createComponent();
        } else {
            this.vcRef.clear();
        }
    }
    constructor(private templateRef: TemplateRef<any>, private vcRef: ViewContainerRef) { }
}
