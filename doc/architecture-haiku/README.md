# DeveloperStore Architecture Haiku

## Objective

- Enable accurate and rule-compliant sales registration across branches.
- Provide item-level detail and discount enforcement based on quantity.
- Support cancellation tracking for sales and individual items.
- Facilitate future integration through event logging and domain clarity.

---

## Functional Requirements

**Sales Registration**
   - The system must allow users to register sales transactions, including customer, branch, and item details.
   - Sales must comply with business rules regarding item quantities and applicable discounts.

**Discount Enforcement**
   - The system must automatically apply discounts based on predefined quantity thresholds.
   - Discounts must be validated to ensure compliance with commercial policies.

**Item-Level Tracking**
   - Each item in a sale must be individually tracked, including quantity, price, and discount applied.

**Sale Cancellation**
   - Users must be able to cancel entire sales.

**Branch Association**
   - Every sale must be associated with a specific branch, and the system must enforce branch-level data segregation where applicable.

**User Roles and Permissions**
   - Only authorized users may perform sales registration and cancellation.
   - Permissions must be configurable based on role and branch.

---

### Domain Core

- **Discount Application**: 
  - Discounts are automatically applied based on quantity thresholds defined per item.
  - Each item may have its own discount policy, which must be enforced consistently.
  - Discounts must be validated against current commercial rules before finalizing a sale.

- **Restrictions:**
  - Max 20 items per product.
  - No discounts below 4 items.