class ProductsViewModel {
    constructor(model) {
        const self = this;        
        if (Array.isArray(model.Products) && (model.Products.length > 0)){
            var _number = 1;
            var products = model.Products.map(p => {
                const numberedProduct = {                    
                    Number: _number,
                    ...p
                };

                _number++;
                return numberedProduct;
            });
            self.products = ko.observableArray(products);
            console.log(`[debug] - self.products(): \n`, self.products()); 
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
        self.products.remove(product);
    }
}