	/* Data SHA1: 7d3b4d70a0569bf9a8772d3e2617ab98a1ac1b95 */
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
	.long	841
	/* entry-length */
	.long	245
	/* value-offset */
	.long	104
	.size	jm_typemap_header, 16

	/* Mapping data */
	.type	jm_typemap, @object
	.global	jm_typemap
jm_typemap:
	.size	jm_typemap, 206046
	.include	"typemap.jm.inc"
