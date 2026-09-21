const products = [
    {
        naam: "Gaming Keyboard",
        prijs: 79.99,
        beoordeling: 4.5
    },
    {
        naam: "Gaming Mouse",
        prijs: 49.99,
        beoordeling: 4.8
    },
    {
        naam: "Gaming Headset",
        prijs: 89.99,
        beoordeling: 4.2
    },
    {
        naam: "Gaming Monitor",
        prijs: 249.99,
        beoordeling: 4.7
    },
    {
        naam: "Mechanical Keyboard",
        prijs: 119.99,
        beoordeling: 4.6
    },
    {
        naam: "Wireless Mouse",
        prijs: 69.99,
        beoordeling: 4.4
    },
    {
        naam: "USB Microphone",
        prijs: 99.99,
        beoordeling: 4.3
    },
    {
        naam: "Webcam",
        prijs: 59.99,
        beoordeling: 4.1
    },
    {
        naam: "Gaming Chair",
        prijs: 299.99,
        beoordeling: 4.6
    },
    {
        naam: "Desk Mat",
        prijs: 24.99,
        beoordeling: 4.5
    },
    {
        naam: "RGB LED Strip",
        prijs: 19.99,
        beoordeling: 4.0
    },
    {
        naam: "External SSD",
        prijs: 129.99,
        beoordeling: 4.8
    },
    {
        naam: "USB Hub",
        prijs: 34.99,
        beoordeling: 4.2
    },
    {
        naam: "Monitor Arm",
        prijs: 79.99,
        beoordeling: 4.4
    },
    {
        naam: "Laptop Stand",
        prijs: 39.99,
        beoordeling: 4.5
    },
    {
        naam: "Bluetooth Speaker",
        prijs: 64.99,
        beoordeling: 4.3
    },
    {
        naam: "Gaming Controller",
        prijs: 69.99,
        beoordeling: 4.7
    },
    {
        naam: "Graphics Tablet",
        prijs: 149.99,
        beoordeling: 4.6
    },
    {
        naam: "Portable Monitor",
        prijs: 199.99,
        beoordeling: 4.4
    },
    {
        naam: "Gaming Mousepad",
        prijs: 29.99,
        beoordeling: 4.8
    },
    {
        naam: "Gaming Laptop",
        prijs: 1299.99,
        beoordeling: 4.7
    },
    {
        naam: "Desktop PC",
        prijs: 1799.99,
        beoordeling: 4.9
    },
    {
        naam: "Graphics Card",
        prijs: 699.99,
        beoordeling: 4.8
    },
    {
        naam: "Computer Processor",
        prijs: 349.99,
        beoordeling: 4.7
    },
    {
        naam: "32GB RAM",
        prijs: 109.99,
        beoordeling: 4.6
    },
    {
        naam: "Motherboard",
        prijs: 189.99,
        beoordeling: 4.5
    },
    {
        naam: "Power Supply",
        prijs: 119.99,
        beoordeling: 4.4
    },
    {
        naam: "PC Case",
        prijs: 99.99,
        beoordeling: 4.3
    },
    {
        naam: "CPU Cooler",
        prijs: 74.99,
        beoordeling: 4.6
    },
    {
        naam: "Case Fans",
        prijs: 39.99,
        beoordeling: 4.2
    },
    {
        naam: "USB Microphone Arm",
        prijs: 44.99,
        beoordeling: 4.5
    },
    {
        naam: "Studio Headphones",
        prijs: 159.99,
        beoordeling: 4.8
    },
    {
        naam: "Wireless Earbuds",
        prijs: 89.99,
        beoordeling: 4.4
    },
    {
        naam: "Smartphone",
        prijs: 799.99,
        beoordeling: 4.6
    },
    {
        naam: "Tablet",
        prijs: 499.99,
        beoordeling: 4.5
    },
    {
        naam: "Smartwatch",
        prijs: 249.99,
        beoordeling: 4.3
    },
    {
        naam: "Powerbank",
        prijs: 39.99,
        beoordeling: 4.2
    },
    {
        naam: "USB-C Cable",
        prijs: 14.99,
        beoordeling: 4.1
    },
    {
        naam: "USB-C Charger",
        prijs: 29.99,
        beoordeling: 4.5
    },
    {
        naam: "Laptop Backpack",
        prijs: 69.99,
        beoordeling: 4.7
    },
    {
        naam: "External Hard Drive",
        prijs: 84.99,
        beoordeling: 4.4
    },
    {
        naam: "Wi-Fi Router",
        prijs: 129.99,
        beoordeling: 4.6
    },
    {
        naam: "Ethernet Cable",
        prijs: 12.99,
        beoordeling: 4.3
    },
    {
        naam: "Network Switch",
        prijs: 49.99,
        beoordeling: 4.2
    },
    {
        naam: "VR Headset",
        prijs: 449.99,
        beoordeling: 4.7
    },
    {
        naam: "Gaming Steering Wheel",
        prijs: 299.99,
        beoordeling: 4.5
    },
    {
        naam: "Flight Simulator Joystick",
        prijs: 179.99,
        beoordeling: 4.4
    },
    {
        naam: "Capture Card",
        prijs: 139.99,
        beoordeling: 4.6
    },
    {
        naam: "Stream Deck",
        prijs: 149.99,
        beoordeling: 4.8
    },
    {
        naam: "Desk Lamp",
        prijs: 34.99,
        beoordeling: 4.3
    },
    {
        naam: "Gaming Footrest",
        prijs: 49.99,
        beoordeling: 4.1
    },
    {
        naam: "Partial Fursuit.",
        prijs: 2080,
        beoordeling: 3.8
    },
    {
        naam: "Fullsuit.",
        prijs: 7500,
        beoordeling: 4.2
    }
];

products.sort((a,b) => a.prijs-b.prijs)
console.log(products)

const productList = document.getElementById("product");

products.forEach(product => {
    const p = document.createElement("p");

    p.textContent = `${product.naam} - €${product.prijs} - ⭐ ${product.beoordeling}`;

    productList.appendChild(p);
})