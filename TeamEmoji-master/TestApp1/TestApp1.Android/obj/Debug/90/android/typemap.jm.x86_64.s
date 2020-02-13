	/* Data SHA1: 64f7f95fa04c8c89fef14ff6e78931fd8dc5d239 */
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
	.long	1014
	/* entry-length */
	.long	249
	/* value-offset */
	.long	108
	.size	jm_typemap_header, 16

	/* Mapping data */
	.type	jm_typemap, @object
	.global	jm_typemap
jm_typemap:
	.size	jm_typemap, 252487
	.include	"typemap.jm.inc"
