-- Create users table
CREATE TABLE IF NOT EXISTS users
(
    id            SERIAL PRIMARY KEY,
    firstname     VARCHAR(255) NOT NULL,
    lastname      VARCHAR(255),
    email         VARCHAR(255) UNIQUE NOT NULL,
    password_hash TEXT NOT NULL
    );

-- Create products table
CREATE TABLE IF NOT EXISTS products
(
    id          SERIAL PRIMARY KEY,
    name        VARCHAR(255) NOT NULL,
    description TEXT
    );

-- Create product_batches table
CREATE TABLE IF NOT EXISTS product_batches
(
    id                SERIAL PRIMARY KEY,
    product_id        INTEGER NOT NULL REFERENCES products(id) ON DELETE CASCADE,
    batch_number      VARCHAR(50) NOT NULL,
    price             NUMERIC(10,2) NOT NULL,
    registration_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT uq_product_batch UNIQUE (product_id, batch_number)
    );


-- Insert 10 products
INSERT INTO products (name, description) VALUES
                                             ('Product 1', 'Description for product 1'),
                                             ('Product 2', 'Description for product 2'),
                                             ('Product 3', 'Description for product 3'),
                                             ('Product 4', 'Description for product 4'),
                                             ('Product 5', 'Description for product 5'),
                                             ('Product 6', 'Description for product 6'),
                                             ('Product 7', 'Description for product 7'),
                                             ('Product 8', 'Description for product 8'),
                                             ('Product 9', 'Description for product 9'),
                                             ('Product 10', 'Description for product 10');

-- Insert 3 product_batches for each product
INSERT INTO product_batches (product_id, batch_number, price)
VALUES
-- Batches for Product 1 (id = 1)
(1, 'Batch1', 10.00),
(1, 'Batch2', 11.50),
(1, 'Batch3', 9.75),

-- Batches for Product 2 (id = 2)
(2, 'Batch1', 20.00),
(2, 'Batch2', 19.95),
(2, 'Batch3', 21.25),

-- Batches for Product 3 (id = 3)
(3, 'Batch1', 30.00),
(3, 'Batch2', 31.50),
(3, 'Batch3', 29.99),

-- Batches for Product 4 (id = 4)
(4, 'Batch1', 40.00),
(4, 'Batch2', 42.00),
(4, 'Batch3', 39.50),

-- Batches for Product 5 (id = 5)
(5, 'Batch1', 50.00),
(5, 'Batch2', 49.95),
(5, 'Batch3', 51.25),

-- Batches for Product 6 (id = 6)
(6, 'Batch1', 60.00),
(6, 'Batch2', 59.50),
(6, 'Batch3', 61.00),

-- Batches for Product 7 (id = 7)
(7, 'Batch1', 70.00),
(7, 'Batch2', 69.95),
(7, 'Batch3', 71.50),

-- Batches for Product 8 (id = 8)
(8, 'Batch1', 80.00),
(8, 'Batch2', 82.00),
(8, 'Batch3', 79.50),

-- Batches for Product 9 (id = 9)
(9, 'Batch1', 90.00),
(9, 'Batch2', 89.95),
(9, 'Batch3', 91.25),

-- Batches for Product 10 (id = 10)
(10, 'Batch1', 100.00),
(10, 'Batch2', 102.00),
(10, 'Batch3', 99.50);


CREATE VIEW vw_ProductBatches AS
SELECT
    p.id AS product_id,
    p.name AS product_name,
    p.description AS product_description,
    pb.batch_number,
    pb.price,
    pb.registration_date as registered
FROM products p
         JOIN product_batches pb ON p.id = pb.product_id;
