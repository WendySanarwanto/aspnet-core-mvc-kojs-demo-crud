class ProductsViewModel {
    constructor(model) {
        const self = this;        
        if (Array.isArray(model.Products) && (model.Products.length > 0)){
            var _number = 1;
            var products = model.Products.map(p => {
                const numberedProduct = {                    
                    Number: ko.observable(_number),
                    ...p,
                    // IsDirty: ko.observable(false),
                    IsDeleted: ko.observable(false),
                };

                _number++;
                return numberedProduct;
            });
            self.products = ko.mapping.fromJS(products);
            console.log(`[debug] - self.products(): \n`, self.products()); 

            self.filteredProducts = ko.computed(() => {
                return ko.utils.arrayFilter(this.products(), product => !product._destroy);
            });            
        }
    }

    addNewProduct() {
        alert('Add new product is not implemented !');
    }

    doSubmit() {
        alert('Submit Products to server is not implemented !');
    }

    removeProduct = (product) => {
        const self = this;
        self.products.destroy(product);

        // update number column:
        // We don't want to remove the to-be-deleted original record. 
        // Because we want to be able to tell backend the to-be-deleted original record(s)
        let number = 1;
        ko.utils.arrayForEach(self.filteredProducts(), _product => {
            if (!_product._destroy){
                _product.Number(number);
                number++;
            }
        });

        // debugger;
    }
}