function createCity(name, population, treasury) {
    return {
        name,
        population,
        treasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth(percentage) {
            this.population = Math.floor(this.population * (1 + percentage / 100));
        },
        applyRecession(percentage) {
            this.treasury = Math.floor(this.treasury * (1 - percentage / 100));
        }
    }
}