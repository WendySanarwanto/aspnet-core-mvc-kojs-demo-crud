class ProductsViewModel {
    constructor(model) {
        const self = this;        
        if (Array.isArray(model.Products) && (model.Products.length > 0)){
            var _number = 1;
            var products = model.Products.map(p => {
                const numberedProduct = {                    
                    Number: ko.observable(_number),
                    ...p,
                    IsDirty: ko.observable(false),
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
        const self = this;
        // TODO: Check if the last row is a new entry and all fields have been filled by user
        const _products = self.products();
        const lastRow = _products[_products.length - 1];
        if (lastRow.Id() >= 0) {
            const newProduct = {
                Number: self.filteredProducts().length+1,
                Id: -1,
                Name: ``,
                Price: 0,
                Amount: 1,
                IsDirty: false,
                _destroy: false
            };
            self.products.push(newProduct);
        }
    }

    doSubmit() {
        alert('Submit Products to server is not implemented !');
        // const self = this;
        // $.ajax("/Products", {
        //     data: ko.toJSON({ Products: self.products }),
        //     type: "post", contentType: "application/json",
        //     success: result => alert(result)
        // });        
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
