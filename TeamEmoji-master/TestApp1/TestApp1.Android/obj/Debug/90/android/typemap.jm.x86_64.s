	/* Data SHA1: b7b90b9f4ce8fb75911d2626b2b254286182d108 */
	.file	"typemap.jm.inc"

	/* Mapping header */
	.section	.data.jm_typemap,"aw",@progbits
	.type	jm_typemap_header, @object
	.p2align	2
	.global	jm_typemap_header
jm_typemap_header:
	/* version */
	.long	1
	/* entry-count */
	.long	828
	/* entry-length */
	.long	245
	/* value-offset */
	.long	104
	.size	jm_typemap_header, 16

	/* Mapping data */
	.type	jm_typemap, @object
	.global	jm_typemap
jm_typemap:
	.size	jm_typemap, 202861
	.include	"typemap.jm.inc"
